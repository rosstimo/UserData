Public Class UserDataForm
    Dim rawData() As String

    Sub Junker()
        Dim tempString As String '= "   234    223    343"
        Dim values(4) As Integer
        values = {123, 456, 765, 224, 677}

        'tempString = CStr(values(0)) & CStr(values(1)) & CStr(values(2)) & CStr(values(3)) & CStr(values(4))

        For i = 0 To UBound(values)
            tempString &= CStr(values(i)).PadLeft(4) & " |"
        Next

        DisplayListBox.Items.Add(tempString)

    End Sub

    Sub LoadFile()
        Dim fileName As String = "C:\Users\rosstimo\OneDrive\Sync\github\_RCET0265-S21\UserData\UserData.txt"
        Dim fileNumber As Integer = FreeFile()
        Dim currentRecord As String
        Dim dataString As String

        FileOpen(fileNumber, fileName, OpenMode.Input)

        Do Until EOF(fileNumber)
            'Input(fileNumber, currentRecord)
            currentRecord = LineInput(fileNumber)
            'DisplayListBox.Items.Add(currentRecord)
            dataString &= currentRecord
        Loop
        rawData = Split(dataString, ",")
        FileClose(fileNumber)
    End Sub

    Private Sub GoButton_Click(sender As Object, e As EventArgs) Handles GoButton.Click
        LoadFile()
        'Junker()
    End Sub
End Class
