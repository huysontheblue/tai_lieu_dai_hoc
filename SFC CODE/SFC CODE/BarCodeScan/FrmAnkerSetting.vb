Imports MainFrame

Public Class FrmAnkerSetting

    Dim dtPartID As DataTable = Nothing
    Dim conn As New MainFrame.SysDataHandle.SysDataBaseClass

    Private Sub FrmAnkerSetting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCboPartID()
    End Sub

    Private Sub LoadCboPartID()
        Dim sql As String = " select distinct PAvcPart, Intime from m_PartContrast_t P where P.CusID = 'Anker' and P.UseY='Y' order by Intime DESC "
        dtPartID = conn.GetDataTable(sql)
        dtPartID.Rows.InsertAt(dtPartID.NewRow, 0)
        Cbo_PartID.DataSource = dtPartID
        Cbo_PartID.DisplayMember = "PAvcPart"
        Cbo_PartID.ValueMember = "PAvcPart"
        conn.PubConnection.Close()
    End Sub

    Private Sub Cbo_PartID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cbo_PartID.SelectedIndexChanged
        Dim dt As DataTable = Nothing
        Dim sql As String = String.Format(" select DValues from m_snpartset_t  where Partid='{0}' ", Cbo_PartID.Text)
        dt = conn.GetDataTable(sql)
        If (dt.Rows.Count > 0) Then
            txt_OldProductCode.Text = dt.Rows(0)("DValues").ToString()
        Else
            txt_OldProductCode.Text = ""
        End If
        txt_NewProductCode.Text = ""
        conn.PubConnection.Close()
    End Sub

    Private Sub btn_SaveAnkerSetting_Click(sender As Object, e As EventArgs) Handles btn_SaveAnkerSetting.Click

        If Cbo_PartID.Text.Trim() = "" Then
            MessageBox.Show("PartID is empty , Please select PartID ")
            Exit Sub
        End If

        If txt_NewProductCode.Text = "" Then
            MessageBox.Show("New Product Code is empty , Please Input New Code  ")
            Exit Sub
        End If

        If Cbo_PartID.Text.Trim() <> "" And txt_NewProductCode.Text <> "" Then

            Dim sql As String = " select  PAvcPart  from m_PartContrast_t P where P.CusID = 'Anker' and P.UseY='Y' and PAvcPart='" & Cbo_PartID.Text.Trim & "' "
            dtPartID = conn.GetDataTable(sql)
            If dtPartID.Rows.Count > 0 Then
                Dim sql_Update As String = ""
                sql_Update = " Update m_snpartset_t set DValues='" & txt_NewProductCode.Text & "' where Packid='S' and Partid='" & Cbo_PartID.Text & "' "
                conn.ExecSql(sql_Update)
                MessageBox.Show(" Updated Product code successful ")
            Else
                MessageBox.Show(" The PartID is not exist in MES system , Please check it again ! ")
            End If
            conn.PubConnection.Close()
        End If

    End Sub
End Class