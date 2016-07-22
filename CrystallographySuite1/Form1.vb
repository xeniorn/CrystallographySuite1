Public Class Form1

    Private ButtonGrid(,) As System.Windows.Forms.Button
    Private PlateType As String
    Private PlateX, PlateY As Integer

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        'GetPlateType()

        'FormGrid()

    End Sub

    Private Sub GetPlateType()

        Select Case True
            Case RadioButton1.Checked
                PlateType = "96"
                PlateX = 12
                PlateY = 8
            Case RadioButton2.Checked
                PlateType = "48"
                PlateX = 8
                PlateY = 6
            Case RadioButton3.Checked
                PlateType = "24"
                PlateX = 6
                PlateY = 4
        End Select

    End Sub

    'Private Sub PlateTypeSelection_Change(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged, RadioButton2.CheckedChanged, RadioButton3.CheckedChanged
    '    DestroyGrid()
    '    GetPlateType()
    '    FormGrid()
    'End Sub

    Private Sub DestroyGrid()

        Dim i, j As Integer
        Dim tempButton As System.Windows.Forms.Button

        If ButtonGrid IsNot Nothing Then

            For i = 0 To UBound(ButtonGrid, 1)
                For j = 0 To UBound(ButtonGrid, 2)
                    tempButton = ButtonGrid(i, j)
                    If tempButton IsNot Nothing Then
                        tempButton.Dispose()
                    End If
                Next
            Next

        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        GetPlateType()
        DestroyGrid()
        FormGrid()
    End Sub

    Private Sub FormGrid()

        Const Margin As Integer = 20
        Const SpacingPercent As Double = 0.02

        Dim i, j As Integer
        Dim tempX, tempY As Integer
        Dim ButtonSpacingX, ButtonSpacingY As Integer
        Dim ButtonGapX, ButtonGapY As Integer
        Dim tempButton As System.Windows.Forms.Button

        Dim ButtonWidth, ButtonHeight As Integer

        Dim Origin As Point

        Origin = New Point(0, 0) 'Panel1.Location

        ReDim ButtonGrid(PlateY - 1, PlateX - 1)

        ButtonSpacingX = (Panel1.Size.Width - 2 * Margin) \ PlateX
        ButtonSpacingY = (Panel1.Size.Height - 2 * Margin) \ PlateY

        ButtonWidth = ButtonSpacingX * (1 - SpacingPercent)
        ButtonHeight = ButtonSpacingY * (1 - SpacingPercent)

        ButtonGapX = (ButtonSpacingX - ButtonWidth) \ 2
        ButtonGapY = (ButtonSpacingY - ButtonHeight) \ 2


        For i = 1 To PlateY
            For j = 1 To PlateX
                tempButton = New System.Windows.Forms.Button
                tempX = Origin.X + Margin + ButtonGapX + (j - 1) * ButtonSpacingX
                tempY = Origin.Y + Margin + ButtonGapY + (i - 1) * ButtonSpacingY

                With tempButton
                    .Location = New Point(tempX, tempY)
                    .Size = New Size(ButtonWidth, ButtonHeight)
                    .Text = Chr(64 + i) & j
                    .BackColor = SystemColors.ControlLight
                End With

                ButtonGrid(i - 1, j - 1) = tempButton

                Panel1.Controls.Add(tempButton)

            Next
        Next



    End Sub


End Class
