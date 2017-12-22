Class MainWindow
    Private Sub Text_PreviewKeyDown(sender As Object, e As KeyEventArgs) 'called when any key is pressed while cursor is in "warning time" or "speed" textbox
        If e.Key = Key.Enter Then                                   'if the pressed key was enter do all this stuff
            If Not SpeedText.Text.Trim.Equals("") Then              'if the speed field is not empty
                If Not WarningTimeText.Text.Trim.Equals("") Then    'if the warning time field is not empty
                    Dim Speed As Double = 0.0                       'create floating point variable for speed
                    Dim WarningTime As Double = 0.0                 'create floating point variable for warning time
                    Try                                 'try these thing incase user entered letters which cannot be turned into numbers error
                        Speed = SpeedText.Text                  'turn the speed string into a number instead of text
                        WarningTime = WarningTimeText.Text      'turn the warning time string into a number instead of text
                    Catch ex As Exception               'if there is an error (user entered letters in a numeric field. handle it this way
                        MsgBox(ex.ToString & vbCrLf & vbCrLf & "Both ""Speed"" and ""Warning Time"" must be numeric.") 'message to user
                        Exit Sub                        'exit this subroputine without finishing out the code after this point (this is only if there was an error)
                    End Try
                    CalculateApproach(Speed, WarningTime)  'call the subroutine to calculate approach time
                End If
            End If
            SpeedOutputLabel.Content = SpeedText.Text & " MPH" 'if speed was entered, display it in the output text regardless of whether warning time was empty or not
        End If
    End Sub

    Private Sub CalculateApproach(speed As Double, time As Double)
        Dim approach As Double = speed * time * (5280.0 / 3600.0) ' make a new variable of the "Double" (floating point) type and do calculation for approach length
        Me.ApproachOutputLabel.Content = Int(approach * 100) / 100.0 & " ft" 'assign string to the output label for approach length with 2 decimal place accuracy
    End Sub

    Private Sub CrossingNameText_TextChanged(sender As Object, e As TextChangedEventArgs) Handles CrossingNameText.TextChanged 'called when the crossingname field's text is changed
        Me.CrossingNameOutputLabel.Content = Me.CrossingNameText.Text 'assigned the users input text to the output label that displays the crossings name
    End Sub

    Private Sub MenuItem_Click(sender As Object, e As RoutedEventArgs) 'called when a menuitem is clicked
        Dim ClickedItem As MenuItem = e.Source 'create new variable "ClickedItem" of the "MenuItem" type and give it the menu item that was clicked
        Select Case ClickedItem.Header 'this is a switch statement using the menu item that was clicked as an argument
            Case "New" 'if "New" menu item was clicked start over with a new form
                ClearFormFields() 'calls sub that clears all user entered data and all output data on the GUI
            Case "Save As" 'if "Save As" menu item was clicked
                SaveFileAs() 'calls sub that will open save as dialog box
        End Select
    End Sub

    Private Sub ClearFormFields()
        'Clear inputs by assigning them empty strings
        CrossingNameText.Text = ""
        SpeedText.Text = ""
        WarningTimeText.Text = ""

        'Clear outputs by assigning them empty strings
        CrossingNameOutputLabel.Content = ""
        ApproachOutputLabel.Content = ""
        SpeedOutputLabel.Content = ""
    End Sub

    Private Sub SaveFileAs()
        Dim SaveDialog As New Microsoft.Win32.SaveFileDialog() 'create new "SaveFileDialog" type object named SaveDialog
        SaveDialog.InitialDirectory = "C:\" 'start directory = C:
        SaveDialog.DefaultExt = ".txt" ' Default file extension
        SaveDialog.Filter = "Text documents (.txt)|*.txt" ' Filter files by extension
        If SaveDialog.ShowDialog Then
            'need to create file still
        End If
    End Sub
End Class
