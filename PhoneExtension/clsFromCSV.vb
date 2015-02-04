Public Class clsFromCSV
    Private PhoneList As DataTable
    Public ReadOnly Property GetPhoneList() As DataTable
        Get
            Return PhoneList
        End Get
    End Property

    Public Sub New()
        Dim myDataTable As New DataTable

        myDataTable.Columns.Add("Name", System.Type.GetType("System.String"))
        myDataTable.Columns.Add("Number", System.Type.GetType("System.String"))
        myDataTable.Columns.Add("Email", System.Type.GetType("System.String"))
        Dim myRow As DataRow

        
        Try
            Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(My.Application.Info.DirectoryPath & "\phonelist.csv")
                MyReader.TextFieldType = FileIO.FieldType.Delimited
                MyReader.SetDelimiters(",")
                Dim currentRow As String()
                While Not MyReader.EndOfData
                    Try
                        currentRow = MyReader.ReadFields()
                        myRow = myDataTable.NewRow
                        If currentRow.GetValue(0) = Nothing Then
                            myRow("Name") = "N/A"
                        Else
                            myRow("Name") = currentRow.GetValue(0)
                        End If
                        If currentRow.GetValue(1) = Nothing Then
                            myRow("Number") = "N/A"
                        Else
                            myRow("Number") = currentRow.GetValue(1)
                        End If
                        If currentRow.GetValue(2) = Nothing Then
                            myRow("Email") = "N/A"
                        Else
                            myRow("Email") = currentRow.GetValue(2)
                        End If

                        myDataTable.Rows.Add(myRow)

                    Catch ex As Microsoft.VisualBasic.
                                FileIO.MalformedLineException
                        MsgBox("Line " & ex.Message &
                        "is not valid and will be skipped.")
                    End Try
                End While
                PhoneList = myDataTable
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            PhoneList = Nothing
        End Try




    End Sub
End Class
