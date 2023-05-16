Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Runtime.InteropServices
Imports System.Threading

Public Class IOC0640
    <DllImport("IOC0640.dll", EntryPoint:="ioc_board_init", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.StdCall)>
    Public Shared Function ioc_board_init() As Integer

    End Function
    <DllImport("IOC0640.dll", EntryPoint:="ioc_board_close", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.StdCall)>
    Public Shared Sub ioc_board_close()

    End Sub
    <DllImport("IOC0640.dll", EntryPoint:="ioc_read_inbit", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.StdCall)>
    Public Shared Function ioc_read_inbit(ByVal cardno As UShort, ByVal bitno As UShort) As Integer

    End Function
    <DllImport("IOC0640.dll", EntryPoint:="ioc_read_outbit", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.StdCall)>
    Public Shared Function ioc_read_outbit(ByVal cardno As UShort, ByVal bitno As UShort) As Integer

    End Function
    <DllImport("IOC0640.dll", EntryPoint:="ioc_write_outbit", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.StdCall)>
    Public Shared Function ioc_write_outbit(ByVal cardno As UShort, ByVal bitno As UShort, ByVal on_off As Integer) As UInteger

    End Function
    <DllImport("IOC0640.dll", EntryPoint:="ioc_read_inport", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.StdCall)>
    Public Shared Function ioc_read_inport(ByVal cardno As UShort, ByVal m_PortNo As UShort) As Integer

    End Function
    <DllImport("IOC0640.dll", EntryPoint:="ioc_read_outport", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.StdCall)>
    Public Shared Function ioc_read_outport(ByVal cardno As UShort, ByVal m_PortNo As UShort) As Integer

    End Function
    <DllImport("IOC0640.dll", EntryPoint:="ioc_write_outport", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.StdCall)>
    Public Shared Function ioc_write_outport(ByVal cardno As UShort, ByVal m_PortNo As UShort, ByVal port_value As UInteger) As UInteger

    End Function
    Public Delegate Function IOC0640_OPERATE(ByVal operate_data As IntPtr) As UInteger
    <DllImport("IOC0640.dll", EntryPoint:="ioc_int_enable", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.StdCall)>
    Public Shared Function ioc_int_enable(ByVal cardno As UShort, ByVal funcIntHandler As IOC0640_OPERATE, ByVal operate_data As IntPtr) As UInteger

    End Function
    <DllImport("IOC0640.dll", EntryPoint:="ioc_int_disable", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.StdCall)>
    Public Shared Function ioc_int_disable(ByVal cardno As UShort) As UInteger

    End Function
    <DllImport("IOC0640.dll", EntryPoint:="ioc_config_intbitmode", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.StdCall)>
    Public Shared Function ioc_config_intbitmode(ByVal cardno As UShort, ByVal bitno As UShort, ByVal enable As UShort, ByVal logic As UShort) As UInteger

    End Function
    <DllImport("IOC0640.dll", EntryPoint:="ioc_config_intbitmode", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.StdCall)>
    Public Shared Function ioc_config_intbitmode(ByVal cardno As UShort, ByVal bitno As UShort, ByVal enable As UShort(), ByVal logic As UShort()) As UInteger

    End Function
    <DllImport("IOC0640.dll", EntryPoint:="ioc_read_intbitstatus", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.StdCall)>
    Public Shared Function ioc_read_intbitstatus(ByVal cardno As UShort, ByVal bitno As UShort) As Integer

    End Function
    <DllImport("IOC0640.dll", EntryPoint:="ioc_config_intporten", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.StdCall)>
    Public Shared Function ioc_config_intporten(ByVal cardno As UShort, ByVal m_PortNo As UShort, ByVal port_en As UInteger) As UInteger

    End Function
    <DllImport("IOC0640.dll", EntryPoint:="ioc_config_intportlogic", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.StdCall)>
    Public Shared Function ioc_config_intportlogic(ByVal cardno As UShort, ByVal m_PortNo As UShort, ByVal port_logic As UInteger) As UInteger

    End Function
    <DllImport("IOC0640.dll", EntryPoint:="ioc_read_intportmode", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.StdCall)>
    Public Shared Function ioc_read_intportmode(ByVal cardno As UShort, ByVal m_PortNo As UShort, ByVal enable As UInteger(), ByVal logic As UInteger()) As UInteger

    End Function
    <DllImport("IOC0640.dll", EntryPoint:="ioc_read_intportstatus", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.StdCall)>
    Public Shared Function ioc_read_intportstatus(ByVal cardno As UShort, ByVal m_PortNo As UShort) As Integer

    End Function
    <DllImport("IOC0640.dll", EntryPoint:="ioc_set_filter", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.StdCall)>
    Public Shared Function ioc_set_filter(ByVal cardno As UShort, ByVal filter As Double) As UInteger

    End Function
    Public Shared Sub writeSign(ByVal a As UShort)

        IOC0640.ioc_write_outbit(0, a, 0)
        ThreadPool.QueueUserWorkItem(New WaitCallback(Sub(obj As Object)
                                                          Thread.Sleep(200)
                                                          IOC0640.ioc_write_outbit(0, a, 1)
                                                      End Sub))
    End Sub
End Class