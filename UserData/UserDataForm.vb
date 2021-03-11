Public Class UserDataForm
    Dim rawData() As String
    Dim cleanData(6, 199) As String

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
        rawData = Split(dataString, "$$") ' Chr(34) & "," & Chr(34) & "$$")

        FileClose(fileNumber)
    End Sub

    Sub DisplayArrayContents()
        Dim temp() As String
        For i = 1 To UBound(rawData)
            temp = Split(rawData(i), Chr(34))
            DisplayListBox.Items.Add(temp(0))
        Next
        Me.Text = CStr(DisplayListBox.Items.Count)
    End Sub

    Sub LoadCleanArray()
        Dim temp() As String
        Dim records() As String
        For i = 1 To UBound(rawData)
            temp = Split(rawData(i), Chr(34))

            records = Split(temp(0), ",")

            cleanData(0, i) = records(0)
            cleanData(1, i) = records(1)
            cleanData(2, i) = ""
            cleanData(3, i) = records(2)
            cleanData(4, i) = ""
            cleanData(5, i) = ""
            cleanData(6, i) = records(3)

        Next

    End Sub

    Private Sub GoButton_Click(sender As Object, e As EventArgs) Handles GoButton.Click
        LoadFile()
        DisplayArrayContents()
        'Junker()
    End Sub
End Class
