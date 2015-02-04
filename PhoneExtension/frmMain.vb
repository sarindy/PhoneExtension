Imports System.Xml
Public Class frmMain
    Public objDataTable As New DataTable
    Public objCSV As New clsFromCSV

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim name As String = InputBox("Please Enter Name to Search... ", "Extension Enquiry", "Mantol")

            If name = "" Then
                Exit Sub
            End If

            objDataTable = objCSV.GetPhoneList
 
            Dim result() As DataRow = objDataTable.Select("name like '%" & name & "%'")
            name = ""
            ' Loop and display.
            For Each row As DataRow In result
                name = name & "Name = " & row(0) & vbCrLf & "Phone No. = " & row(1) & vbCrLf & "Email. = " & row(2) & vbCrLf
            Next
            MsgBox(name)

        Catch ex As ArgumentException
            MsgBox(ex.Message)
            'conStr = "N/A"
        End Try
    End Sub

    Private Sub frmMain_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        Button1.Focus()
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'objDataTable = callXML()

    End Sub
    Private Function callXML() As DataTable
        Try

            Dim m_xmld As XmlDocument
            Dim m_nodelist As XmlNodeList
            Dim m_node As XmlNode

            Dim myDataTable As New DataTable

            myDataTable.Columns.Add("Name", System.Type.GetType("System.String"))
            myDataTable.Columns.Add("Number", System.Type.GetType("System.String"))
            Dim myRow As DataRow
            'Create the XML Document
            m_xmld = New XmlDocument()
            'Load the Xml file
            m_xmld.Load(My.Application.Info.DirectoryPath & "\phone_list.xml")
            'Get the list of name nodes 
            m_nodelist = m_xmld.SelectNodes("/phone_list/contact")
            'Loop through the nodes
            For Each m_node In m_nodelist
                'Get the firstName Element Value
                'conStr = m_node.ChildNodes.Item(0).InnerText
                myRow = myDataTable.NewRow
                myRow("Name") = m_node.ChildNodes.Item(0).InnerText
                myRow("Number") = m_node.ChildNodes.Item(1).InnerText

                myDataTable.Rows.Add(myRow)



            Next

            Return myDataTable


        Catch ex As ArgumentException
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function
End Class