namespace SysBasicClass
{
    ///winform分页控件--带自定义分页数量，带自定义导出EXCEl功能,传入参数为查询SQL语句，详细用法参考通用报表查询里面的使用方法 by hs ke 2017-3-10
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Data;
    using System.Data.SqlClient;
    using System.Text;
    using System.Windows.Forms;
   

    /// <summary>
    /// 申明委托
    /// </summary>
    /// <param name="e"></param>
    /// <returns></returns>
    public delegate int EventPagingHandler(EventPagingArg e);
    /// <summary>
    /// 申明委托
    /// </summary>
    /// <param name="e"></param>
    /// <returns></returns>
    public delegate void ExportDataHandler(ExportDataArg e);
    /// <summary>
    /// 申明委托
    /// </summary>
    /// <param name="e"></param>
    /// <returns></returns>
    public delegate void ExportAllDataHandler(ExportAllDataArg e);
    
    /// <summary>
    /// 分页控件呈现
    /// </summary>
    public partial class Pager : UserControl
    {

        public Pager()
        {
            InitializeComponent();
        }
        public event EventPagingHandler EventPaging;
        public event ExportDataHandler ExportData;
        public event ExportAllDataHandler ExportAllData;
        /// <summary>
        /// 每页显示记录数
        /// </summary>
        private int _pageSize = 20;
        /// <summary>
        /// 每页显示记录数
        /// </summary>
        public int PageSize
        {
            get {
                if (TxtPageSize.Text != "")
                {
                    _pageSize =Int16.Parse(TxtPageSize.Text);
                }
                return _pageSize; 
            }
            set
            {
                _pageSize = value;
                TxtPageSize.Text = _pageSize.ToString();
                GetPageCount();
            }
        }

        private int _nMax = 0;
        /// <summary>
        /// 总记录数
        /// </summary>
        public int NMax
        {
            get { return _nMax; }
            set
            {
                _nMax = value;
                GetPageCount();
            }
        }
        private double _QuerySeconds = 0;
        /// <summary>
        /// 花费时间=查询数据花费的秒数
        /// </summary>
        public double QuerySeconds
        {
            get { return _QuerySeconds; }
            set { _QuerySeconds = value; }
        }
        private bool _isExport = true;//是否允许导出当前页
        private bool _isExportAll = true;//是否允许导出所有页
        /// <summary>
        /// 是否允许导出当前页数据
        /// </summary>
        public bool ExportPageDataToXls
        {
            get { return _isExport; }
            set { _isExport = value; }
        }
        /// <summary>
        /// 是否允许导出所有页数据
        /// </summary>
        public bool ExportAllDataToXls
        {
            get { return _isExportAll; }
            set { _isExportAll = value; }
        }
       
        private int _pageCount = 0;
        /// <summary>
        /// 页数=总记录数/每页显示记录数
        /// </summary>
        public int PageCount
        {
            get { return _pageCount; }
            set { _pageCount = value; }
        }

        private int _pageCurrent = 0;
        /// <summary>
        /// 当前页号
        /// </summary>
        public int PageCurrent
        {
            get { return _pageCurrent; }
            set { _pageCurrent = value; }
        }

        public BindingNavigator ToolBar
        {
            get { return this.bindingNavigator; }
        }

        private void GetPageCount()
        {
            if (this.NMax > 0)
            {
                this.PageCount = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(this.NMax) / Convert.ToDouble(this.PageSize)));
            }
            else
            {
                this.PageCount = 0;
            }
        }

        /// <summary>
        /// 翻页控件数据绑定的方法
        /// </summary>
        public void Bind()
        {
            btnGo.Enabled = true;
            TxtPageSize.Enabled = true;
            txtCurrentPage.Enabled = true;
            if (this.EventPaging != null)
            {
                this.NMax = this.EventPaging(new EventPagingArg(this.PageCurrent));
            }

            if (this.PageCurrent > this.PageCount)
            {
                this.PageCurrent = this.PageCount;
            }
            if (this.PageCount == 1 || this.PageCurrent <= 0)
            {
                this.PageCurrent = 1;
            }
            lblPageCount.Text = this.PageCount.ToString();
            this.lblMaxPage.Text = "共" + this.NMax.ToString() + "条记录";
            this.txtCurrentPage.Text = this.PageCurrent.ToString();

            if (this.PageCurrent == 1)
            {
                this.btnPrev.Enabled = false;
                this.btnFirst.Enabled = false;
            }
            else
            {
                btnPrev.Enabled = true;
                btnFirst.Enabled = true;
            }

            if (this.PageCurrent == this.PageCount)
            {
                this.btnLast.Enabled = false;
                this.btnNext.Enabled = false;
            }
            else
            {
                btnLast.Enabled = true;
                btnNext.Enabled = true;
            }

            if (this.NMax == 0)
            {
                btnNext.Enabled = false;
                btnLast.Enabled = false;
                btnFirst.Enabled = false;
                btnPrev.Enabled = false;
                lblExport.Enabled = false;
                lblExportAll.Enabled = false;
            }
            else
            {
                lblExport.Enabled = true;
                lblExportAll.Enabled = true;
            }
            if (ExportPageDataToXls || ExportPageDataToXls)
            {
                toolStripSeparator1.Visible = true;
            }
            else
            {
                toolStripSeparator1.Visible = false;
            }
            lblExport.Visible = ExportPageDataToXls;
            lblExportAll.Visible = ExportAllDataToXls;
            lblsec.Text = this.QuerySeconds.ToString();
        }
        /// <summary>
        /// 导出按钮
        /// </summary>
        public void SetExportEnabled()
        {
            btnNext.Enabled = false;
            btnLast.Enabled = false;
            btnFirst.Enabled = false;
            btnPrev.Enabled = false;
            lblExport.Enabled = true;
            lblExportAll.Enabled = false;
            btnGo.Enabled = false;
            TxtPageSize.Enabled = false;
            txtCurrentPage.Enabled = false;
            lblExport.Visible = ExportPageDataToXls;
            lblExportAll.Visible = ExportAllDataToXls;
        }
        private void btnFirst_Click(object sender, EventArgs e)
        {
            PageCurrent = 1;
            this.Bind();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            PageCurrent -= 1;
            if (PageCurrent <= 0)
            {
                PageCurrent = 1;
            }
            this.Bind();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            this.PageCurrent += 1;
            if (PageCurrent > PageCount)
            {
                PageCurrent = PageCount;
            }
            this.Bind();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            PageCurrent = PageCount;
            this.Bind();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            if (this.TxtPageSize.Text != null && TxtPageSize.Text != "")
            {
                if (this.TxtPageSize.Text == "0")
                {
                    MessageBox.Show("输入分页数字不能为0！");
                    this.TxtPageSize.Text = _pageSize.ToString();
                }
                else
                {
                    if (Int32.TryParse(TxtPageSize.Text, out _pageSize))
                    {
                        if (this.txtCurrentPage.Text != null && txtCurrentPage.Text != "")
                        {
                            if (Int32.TryParse(txtCurrentPage.Text, out _pageCurrent))
                            {
                                this.Bind();
                            }
                            else
                            {
                                MessageBox.Show("输入页码数字格式错误！");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("输入分页数字格式错误！");
                    }
                }
            }
            
        }

        private void txtCurrentPage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnGo_Click(sender, e);
            }
        }
        private void TxtPageSize_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnGo_Click(sender, e);
            }
        }
        private void lblExport_Click(object sender, EventArgs e)
        {
            try
            {
                this.ExportData(new ExportDataArg());
            }
            catch
            {

            }
        }

        private void lblExportAll_Click(object sender, EventArgs e)
        {       
            this.ExportAllData(new ExportAllDataArg());
        }

        

        
       

    }
    /// <summary>
    /// 自定义事件数据基类
    /// </summary>
    public class EventPagingArg : EventArgs
    {
        private int _intPageIndex;
        public EventPagingArg(int PageIndex)
        {
            _intPageIndex = PageIndex;
        }
    }
    /// <summary>
    /// 自定义导出当前页数据基类
    /// </summary>
    public class ExportDataArg : EventArgs
    {
        public ExportDataArg()
        {
            
        }
    }
    /// <summary>
    /// 自定义导出所有页数据基类
    /// </summary>
    public class ExportAllDataArg : EventArgs
    {
        public ExportAllDataArg()
        {

        }
    }

    /// <summary>
    /// 数据源提供
    /// </summary>
    public class PageData
    {
        private int _PageSize = 10;
        private int _PageIndex = 1;
        private int _PageCount = 0;
        private int _TotalCount = 0;
        private string _QuerySQL;//查询SQL
        private SqlParameter[] _QueryParam;
       // MainFrame.SysDataHandle.SysDataBaseClass Conn;
        public SqlParameter[] QueryParam
        {
            get { return _QueryParam; }
            set { _QueryParam = value; }
        }
        private string _QueryFieldName = "*";//表字段FieldStr        
        private string _OrderStr = string.Empty; //排序_SortStr
        private string _RowNumberOrderStr = string.Empty; //排序_RowNumberOrderStr
   
       
        private string _PrimaryKey = string.Empty;//主键
        private bool _isQueryTotalCounts = true;//是否查询总的记录条数
       
        public PageData()
        {
        }

        /// <summary>
        /// 是否查询总的记录条数
        /// </summary>
        public bool IsQueryTotalCounts
        {
            get { return _isQueryTotalCounts; }
            set { _isQueryTotalCounts = value; }
        }
        private bool _isLoaclQuery = false;//是否查询本地数据库
        /// <summary>
        /// 是否查询本地数据库
        /// </summary>
        public bool IsLoaclQuery
        {
            get { return _isLoaclQuery; }
            set { _isLoaclQuery = value; }
        }
        /// <summary>
        /// 显示页数
        /// </summary>
        public int PageSize
        {
            get
            {
                return _PageSize;

            }
            set
            {
                _PageSize = value;
            }
        }
        /// <summary>
        /// 当前页
        /// </summary>
        public int PageIndex
        {
            get
            {
                if (_PageIndex == 0)
                    _PageIndex = 1;
                return _PageIndex;
            }
            set
            {
                _PageIndex = value;
            }
        }
        /// <summary>
        /// 总页数
        /// </summary>
        public int PageCount
        {
            get
            {
                return _PageCount;
            }
        }
        /// <summary>
        /// 总记录数
        /// </summary>
        public int TotalCount
        {
            get
            {
                return _TotalCount;
            }
        }
        /// <summary>
        /// 查询SQL
        /// </summary>
        public string QuerySQL
        {
            get
            {
                return _QuerySQL;
            }
            set
            {
                _QuerySQL = value;
            }
        }
        /// <summary>
        /// 表字段FieldStr
        /// </summary>
        public string QueryFieldName
        {
            get
            {
                return _QueryFieldName;
            }
            set
            {
                _QueryFieldName = value;
            }
        }


        /// <summary>
        /// ROW_NUMBER()排序字段
        /// </summary>
        public string RowNumberOrderStr
        {
            get
            {
                return _RowNumberOrderStr;
            }
            set
            {
                _RowNumberOrderStr = value;
            }
        }
        /// <summary>
        /// 排序字段
        /// </summary>
        public string OrderStr
        {
            get
            {
                return _OrderStr;
            }
            set
            {
                _OrderStr = value;
            }
        }
      
        /// <summary>
        /// 主键
        /// </summary>
        public string PrimaryKey
        {
            get
            {
                return _PrimaryKey;
            }
            set
            {
                _PrimaryKey = value;
            }
        }
        private double _QuerySeconds = 0;
        /// <summary>
        /// 花费时间=查询数据花费的秒数
        /// </summary>
        public double QuerySeconds
        {
            get { return _QuerySeconds; }
            set { _QuerySeconds = value; }
        }
        public string GroupBy { get; set; }
 
        /// <summary>
        /// 在不使用分页存储过程的情况下，对应的获取数据的SQL
        /// </summary>
        public string GetDataSQL
        {
            get
            {
                string r = string.Empty;
                int _recordCount = GetTotalCount();
                if (_OrderStr == "")
                {
                    r = CreatePagingSql(_recordCount, _PageSize, _PageIndex, _QuerySQL);
                }
                else
                {
                    r = CreatePagingSql(_recordCount, _PageSize, _PageIndex, _QuerySQL, _OrderStr);
                }
                return r;
            }
        }
        /// <summary>
        /// 在不使用分页存储过程的情况下，对应的获取数据的SQL
        /// </summary>
        public string GetAllDataSQL
        {
            get
            {
                string r = string.Empty;
                int _recordCount = GetTotalCount();
                if (_OrderStr == "")
                {
                    r = CreatePagingSql(_recordCount, _recordCount, _PageIndex, _QuerySQL);
                }
                else
                {
                    r = CreatePagingSql(_recordCount, _recordCount, _PageIndex, _QuerySQL, _OrderStr);
                }
                return r;
            }
        }
        public DataTable QueryDataTable()
        {
            DateTime startTime = DateTime.Now;
            DataTable ds = null;
            if (IsLoaclQuery)
            {
                ds = new MainFrame.SysDataHandle.SysBaseClassLocal().GetDataTable(this.GetDataSQL, QueryParam);
            }
            else
            {
                ds = new MainFrame.SysDataHandle.SysDataBaseClassReport().GetDataTable(this.GetDataSQL, QueryParam);
            }
            if (_isQueryTotalCounts)
            {
                _TotalCount = GetTotalCount();
            }
            if (_TotalCount == 0)
            {
                _PageIndex = 0;
                _PageCount = 0;
            }
            else
            {
                _PageCount = _TotalCount % _PageSize == 0 ? _TotalCount / _PageSize : _TotalCount / _PageSize + 1;
                if (_PageIndex > _PageCount)
                {
                    _PageIndex = _PageCount;
                    ds = QueryDataTable();
                }
            }
            TimeSpan ts = DateTime.Now - startTime;
            _QuerySeconds = Math.Round(ts.TotalSeconds, 3);
            return ds;


        }
        public DataTable QueryAllDataTable()
        {
            if (IsLoaclQuery)
            {
                return new MainFrame.SysDataHandle.SysBaseClassLocal().GetDataTable(this.GetAllDataSQL, this.QueryParam);
            }
            else
            {
                return new MainFrame.SysDataHandle.SysDataBaseClassReport().GetDataTable(this.GetAllDataSQL, this.QueryParam);
            }
        }
        public int GetTotalCount()
        {
            string strSql = " select 1 from " + _QuerySQL;
            
            if (_QuerySQL.IndexOf("select ") >= 0 || _QuerySQL.IndexOf("SELECT ") >= 0)
            {
                strSql = CreateCountingSql(_QuerySQL);              
            }
            if (IsLoaclQuery)
            {
                return int.Parse(new MainFrame.SysDataHandle.SysBaseClassLocal().GetDataTable(strSql, this.QueryParam).Rows[0][0].ToString());
            }
            else
            {
                return int.Parse(new MainFrame.SysDataHandle.SysDataBaseClassReport().GetDataTable(strSql, this.QueryParam).Rows[0][0].ToString());
            }
        }
        public string GetFirstField()
        {
            string strSql = string.Format(" SELECT top 0 * FROM ({0}) AS T ", _QuerySQL);
            if (IsLoaclQuery)
            {
                return new MainFrame.SysDataHandle.SysBaseClassLocal().GetDataTable(this.GetAllDataSQL, this.QueryParam).Columns[0].ColumnName;
            }
            else
            {
                return new MainFrame.SysDataHandle.SysDataBaseClassReport().GetDataTable(this.GetAllDataSQL, this.QueryParam).Columns[0].ColumnName;
            }
        }
        /// <summary>
        /// 获取分页SQL语句，排序字段需要构成唯一记录-特别针对有排序字段的
        /// </summary>
        /// <param name="_recordCount">记录总数</param>
        /// <param name="_pageSize">每页记录数</param>
        /// <param name="_pageIndex">当前页数</param>
        /// <param name="_safeSql">SQL查询语句</param>
        /// <param name="_orderField">排序字段，多个则用“,”隔开</param>
        /// <returns>分页SQL语句</returns>
        public string CreatePagingSql(int _recordCount, int _pageSize, int _pageIndex, string _safeSql, string _orderField)
        {
            //重新组合排序字段，防止有错误
            string[] arrStrOrders = _orderField.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder sbOriginalOrder = new StringBuilder(); //原排序字段
            StringBuilder sbReverseOrder = new StringBuilder(); //与原排序字段相反，用于分页
            for (int i = 0; i < arrStrOrders.Length; i++)
            {
                arrStrOrders[i] = arrStrOrders[i].Trim();  //去除前后空格
                if (i != 0)
                {
                    sbOriginalOrder.Append(", ");
                    sbReverseOrder.Append(", ");
                }
                sbOriginalOrder.Append(arrStrOrders[i]);

                int index = arrStrOrders[i].IndexOf(" "); //判断是否有升降标识
                if (index > 0)
                {
                    //替换升降标识，分页所需
                    bool flag = arrStrOrders[i].IndexOf(" DESC", StringComparison.OrdinalIgnoreCase) != -1;
                    sbReverseOrder.AppendFormat("{0} {1}", arrStrOrders[i].Remove(index), flag ? "ASC" : "DESC");
                }
                else
                {
                    sbReverseOrder.AppendFormat("{0} DESC", arrStrOrders[i]);
                }
            }

            //计算总页数
            _pageSize = _pageSize == 0 ? _recordCount : _pageSize;
            int pageCount = (_recordCount + _pageSize - 1) / _pageSize;

            //检查当前页数
            if (_pageIndex < 1)
            {
                _pageIndex = 1;
            }
            else if (_pageIndex > pageCount)
            {
                _pageIndex = pageCount;
            }

            StringBuilder sbSql = new StringBuilder();
            //第一页时，直接使用TOP n，而不进行分页查询
            if (_pageIndex == 1)
            {
                sbSql.AppendFormat(" SELECT TOP {0} * ", _pageSize);
                sbSql.AppendFormat(" FROM ({0}) AS T ", _safeSql);
                if (arrStrOrders.Length > 0)
                {
                    sbSql.AppendFormat(" ORDER BY {0} ", sbOriginalOrder.ToString());
                }
            }
            //最后一页时，减少一个TOP
            else if (_pageIndex == pageCount)
            {
                sbSql.Append(" SELECT * FROM ");
                sbSql.Append(" ( ");
                sbSql.AppendFormat(" SELECT TOP {0} * ", _recordCount - _pageSize * (_pageIndex - 1));
                sbSql.AppendFormat(" FROM ({0}) AS T ", _safeSql);
                if (arrStrOrders.Length > 0)
                {
                    sbSql.AppendFormat(" ORDER BY {0} ", sbReverseOrder.ToString());
                }
                sbSql.Append(" ) AS T ");
                if (arrStrOrders.Length > 0)
                {
                    sbSql.AppendFormat(" ORDER BY {0} ", sbOriginalOrder.ToString());
                }
            }
            //前半页数时的分页
            else if (_pageIndex <= (pageCount / 2 + pageCount % 2) + 1)
            {
                sbSql.Append(" SELECT * FROM ");
                sbSql.Append(" ( ");
                sbSql.AppendFormat(" SELECT TOP {0} * FROM ", _pageSize);
                sbSql.Append(" ( ");
                sbSql.AppendFormat(" SELECT TOP {0} * ", _pageSize * _pageIndex);
                sbSql.AppendFormat(" FROM ({0}) AS T ", _safeSql);
                if (arrStrOrders.Length > 0)
                {
                    sbSql.AppendFormat(" ORDER BY {0} ", sbOriginalOrder.ToString());
                }
                sbSql.Append(" ) AS T ");
                {
                    sbSql.AppendFormat(" ORDER BY {0} ", sbReverseOrder.ToString());
                }
                sbSql.Append(" ) AS T ");
                {
                    sbSql.AppendFormat(" ORDER BY {0} ", sbOriginalOrder.ToString());
                }
            }
            //后半页数时的分页
            else
            {
                sbSql.AppendFormat(" SELECT TOP {0} * FROM ", _pageSize);
                sbSql.Append(" ( ");
                sbSql.AppendFormat(" SELECT TOP {0} * ", ((_recordCount % _pageSize) + _pageSize * (pageCount - _pageIndex) + 1));
                sbSql.AppendFormat(" FROM ({0}) AS T ", _safeSql);
                {
                    sbSql.AppendFormat(" ORDER BY {0} ", sbReverseOrder.ToString());
                }
                sbSql.Append(" ) AS T ");
                {
                    sbSql.AppendFormat(" ORDER BY {0} ", sbOriginalOrder.ToString());
                }
            }
            return sbSql.ToString();
        }
        public string CreatePagingSql(int items_count, int _pageSize, int _pageIndex, string strSql)
        {
            int start_item = 0;
            //计算总页数
            _pageSize = _pageSize == 0 ? items_count : _pageSize;
            int pageCount = (items_count + _pageSize - 1) / _pageSize;

            //检查当前页数
            if (_pageIndex < 1)
            {
                _pageIndex = 1;
            }
            else if (_pageIndex > pageCount)
            {
                _pageIndex = pageCount;
            }
            StringBuilder _sbSql = new StringBuilder();
            StringBuilder _Sql = new StringBuilder();
            if (strSql.Length > 6 && strSql.Substring(0, 6).ToLower() == "select")
            {
                if (!string.IsNullOrEmpty(_RowNumberOrderStr))
                {
                    _sbSql.Append(" select ROW_NUMBER() OVER (order by "+_RowNumberOrderStr+") as RowId, ");
                }
                else 
                {
                    _sbSql.Append(" select ROW_NUMBER() OVER (order by GETDATE()) as RowId, ");
                }
             
                _sbSql = _sbSql.Append(strSql.Substring(7, strSql.Length - 7));
            }
            start_item = _pageSize * (_pageIndex-1);
            _Sql.Append("select * from ( ").Append(_sbSql).Append(" ) as T  where T.RowId >= " + (start_item + 1).ToString() + " AND T.RowId <= " + (start_item + _pageSize).ToString());
           

            return _Sql.ToString();
        }
        /// <summary>
        /// 获取记录总数SQL语句
        /// </summary>
        /// <param name="_n">限定记录数</param>
        /// <param name="_safeSql">SQL查询语句</param>
        /// <returns>记录总数SQL语句</returns>
        public string CreateTopnSql(int _n, string _safeSql)
        {
            return string.Format(" SELECT TOP {0} * FROM ({1}) AS T ", _n, _safeSql);
        }

        /// <summary>
        /// 获取记录总数SQL语句
        /// </summary>
        /// <param name="_safeSql">SQL查询语句</param>
        /// <returns>记录总数SQL语句</returns>
        public string CreateCountingSql(string _safeSql)
        {
            return string.Format(" SELECT count(*) AS RecordCount FROM ({0}) AS T ", _safeSql);
        }

    }
}
