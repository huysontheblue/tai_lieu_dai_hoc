Imports System.Windows.Forms
Public Class Tips
    Shared tipform As TipForm
    'add by song
    '2016-05-09
    '设置窗口中Label等控件的提示
    Public Shared Sub FormTip(ByVal form As System.Windows.Forms.Form)
        AddHandler form.MouseMove, AddressOf Label_Leave
        SetTip(form)
    End Sub

    'add by song
    '2016-09-26
    '设置控件Tip值
    Public Shared Sub SetTip(ByVal form As System.Windows.Forms.Form)
        Dim ct As Control
        For Each ct In form.Controls
            If ct.HasChildren Then
                SetControlTip(form, ct)
            End If
            If (TypeOf ct Is Label) Then
                CType(ct, Label).AutoSize = False
                If form.Name = "FrmLogin" Then
                    If ct.Name <> "CmdOk" And ct.Name <> "CmdCancel" Then
                        AddHandler ct.MouseHover, AddressOf Label_Hover
                    End If
                Else
                    AddHandler ct.MouseHover, AddressOf Label_Hover
                End If
            End If

            If (TypeOf ct Is CheckBox) Then
                CType(ct, CheckBox).AutoSize = False
                If form.Name = "FrmLogin" Then
                    AddHandler ct.MouseHover, AddressOf Label_Hover
                End If
            End If
        Next
    End Sub

    'add by song
    '2016-09-26
    '设置控件Tip值
    Public Shared Sub SetControlTip(ByVal form As System.Windows.Forms.Form, ByVal c As System.Windows.Forms.Control)
        Dim ct As Control
        For Each ct In c.Controls
            If ct.HasChildren Then
                SetControlTip(form, ct)
            End If
            If (TypeOf ct Is Label) Then
                CType(ct, Label).AutoSize = True
                AddHandler ct.MouseHover, AddressOf Label_Hover
            ElseIf (TypeOf ct Is CheckBox) Then
                CType(ct, CheckBox).AutoSize = True
                AddHandler ct.MouseHover, AddressOf Label_Hover
            ElseIf (TypeOf ct Is DevComponents.DotNetBar.Controls.CheckBoxX) Then
                CType(ct, DevComponents.DotNetBar.Controls.CheckBoxX).AutoSize = True
                AddHandler ct.MouseHover, AddressOf Label_Hover
            ElseIf (TypeOf ct Is RadioButton) Then
                CType(ct, RadioButton).AutoSize = True
                AddHandler ct.MouseHover, AddressOf Label_Hover
            End If
            
        Next
    End Sub

    'add by song
    '2016-05-09
    '鼠标在Lable上时触发
    Private Shared Sub Label_Hover(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim x As Integer = 0
        'Dim y As Integer = 0
        tipform = New TipForm()
        If MultLanguage.Language.lang = "en" Then
            If (TypeOf sender Is Label) Then
                CType(sender, Label).Cursor = Cursors.Hand
                tipform.Label1.Text = MultLanguage.Language.GetFullText(CType(sender, Label).FindForm.Name, CType(sender, Label).Name)
                tipform.Width = tipform.Label1.Width + 30
                '        tipform.Left = CType(sender, Label).FindForm.Left + CType(sender, Label).Left
                '        x = CType(sender, Label).FindForm.Left
                '        y = CType(sender, Label).FindForm.Top
                '        If (Not CType(sender, Label).Parent Is Nothing) And ((TypeOf sender.Parent Is Panel) Or (TypeOf sender.Parent Is GroupBox)) Then
                '            If CType(sender, Label).FindForm.Name = "FrmLogin" Then
                '                tipform.Top = y + CType(sender, Label).Parent.Location.Y + CType(sender, Label).Top + 30
                '            ElseIf CType(sender, Label).FindForm.Name = "FrmModuleManage" Then
                '                tipform.Left = CType(sender, Label).Parent.Location.X + CType(sender, Label).Left + 80
                '                tipform.Top = CType(sender, Label).Parent.Location.Y + CType(sender, Label).Top + 200
                '            Else
                '                tipform.Top = CType(sender, Label).Parent.Location.Y + CType(sender, Label).Top + 190
                '            End If
                '        Else
                '            tipform.Top = y + CType(sender, Label).Top + 30
                'End If
            ElseIf (TypeOf sender Is CheckBox) Then
                CType(sender, CheckBox).Cursor = Cursors.Hand
                tipform.Label1.Text = MultLanguage.Language.GetFullText(CType(sender, CheckBox).FindForm.Name, CType(sender, CheckBox).Name)
                tipform.Width = tipform.Label1.Width + 30
                '        tipform.Left = CType(sender, CheckBox).FindForm.Left + CType(sender, CheckBox).Left
                '        x = CType(sender, CheckBox).FindForm.Left
                '        y = CType(sender, CheckBox).FindForm.Top
                '        If (Not CType(sender, CheckBox).Parent Is Nothing) And ((TypeOf sender.Parent Is Panel) Or (TypeOf sender.Parent Is GroupBox)) Then
                '            If CType(sender, CheckBox).FindForm.Name = "FrmLogin" Then
                '                tipform.Top = y + CType(sender, CheckBox).Parent.Location.Y + CType(sender, CheckBox).Top + 30
                '            ElseIf CType(sender, CheckBox).FindForm.Name = "FrmModuleManage" Then
                '                tipform.Left = x + CType(sender, CheckBox).Parent.Location.X + CType(sender, CheckBox).Left + 200
                '            Else
                '                tipform.Top = CType(sender, CheckBox).Parent.Location.Y + CType(sender, CheckBox).Top + 190
                '            End If
                '        Else
                '            tipform.Top = y + CType(sender, CheckBox).Top + 30
                '        End If
            ElseIf (TypeOf sender Is RadioButton) Then
                CType(sender, RadioButton).Cursor = Cursors.Hand
                tipform.Label1.Text = MultLanguage.Language.GetFullText(CType(sender, RadioButton).FindForm.Name, CType(sender, RadioButton).Name)
                tipform.Width = tipform.Label1.Width + 30
            ElseIf (TypeOf sender Is DevComponents.DotNetBar.Controls.CheckBoxX) Then
                CType(sender, DevComponents.DotNetBar.Controls.CheckBoxX).Cursor = Cursors.Hand
                tipform.Label1.Text = MultLanguage.Language.GetFullText(CType(sender, DevComponents.DotNetBar.Controls.CheckBoxX).FindForm.Name, CType(sender, DevComponents.DotNetBar.Controls.CheckBoxX).Name)
                tipform.Width = tipform.Label1.Width + 30
            End If
            tipform.Left = System.Windows.Forms.Cursor.Position.X + 15
            tipform.Top = System.Windows.Forms.Cursor.Position.Y + 15
            tipform.Show()
        End If
    End Sub

    'add by song
    '2016-05-09
    '鼠标离开Label时触发
    Private Shared Sub Label_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If tipform Is Nothing Then
            Return
        End If
        If MultLanguage.Language.lang = "en" Then
            tipform.Close()
        End If
    End Sub
End Class
