Class MainWindow
    Private Sub Text_PreviewKeyDown(sender As Object, e As KeyEventArgs)
        If e.Key = Key.Enter Then
            If Not SpeedText.Text.Trim.Equals("") Then
                If Not WarningTimeText.Text.Trim.Equals("") Then
                    Dim Speed As Double = 0.0
                    Dim WarningTime As Double = 0.0
                    Try
                        Speed = SpeedText.Text
                        WarningTime = WarningTimeText.Text
                    Catch ex As Exception
                        MsgBox(ex.ToString & vbCrLf & vbCrLf & "Both ""Speed"" and ""Warning Time"" must be numeric.")
                        Exit Sub
                    End Try
                    CalculateApproach(Speed, WarningTime)
                End If
            End If
            SpeedOutputLabel.Content = SpeedText.Text & " MPH"
        End If
    End Sub

    Private Sub CalculateApproach(speed As Double, time As Double)
        Dim approach As Double = speed * time * (5280.0 / 3600.0)
        Me.ApproachOutputLabel.Content = Int(approach * 100) / 100.0 & " ft"
    End Sub

    Private Sub CrossingNameText_TextChanged(sender As Object, e As TextChangedEventArgs) Handles CrossingNameText.TextChanged
        Me.CrossingNameOutputLabel.Content = Me.CrossingNameText.Text
    End Sub
End Class
