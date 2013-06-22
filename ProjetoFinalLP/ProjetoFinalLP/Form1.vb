Public Class Form1

    Private CliID As Integer
    Private Artigo As Integer


    Private Sub TabPage1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Database1DataSet.Artigos' table. You can move, or remove it, as needed.
        Me.ArtigosTableAdapter.Fill(Me.Database1DataSet.Artigos)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Application.Exit()
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub TabPage2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage2.Click

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        CliID = Nothing
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If CliID = Nothing Then
            Dim cli As New Artigo
            cli.novoArtigo(Me.TextBox2.Text, Me.TextBox3.Text, _
            Me.TextBox4.Text, Me.TextBox5.Text, Me.TextBox6.Text)

            If cli.erro Then
                MessageBox.Show("Erro a inserir registo", "Empresa :: Clientes", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show("Registo inserido com sucesso", "Empresa :: Clientes", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else 'Actualizar Registo
            'ToDo
        End If
    End Sub

    Private Sub ArtigosBindingNavigatorSaveItem_Click(sender As System.Object, e As System.EventArgs)
        Me.Validate()
        Me.ArtigosBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.Database1DataSet)

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim cli As New Cliente
        Dim confirmar As String

        confirmar = MessageBox.Show("Eliminar registo?", "Empresa :: Clientes", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If confirmar = Windows.Forms.DialogResult.Yes Then
            cli.eliminarCliente(Me.TextBox1.Text)

            If cli.erro Then
                MessageBox.Show("Erro a eliminar registo", "Empresa :: Clientes", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show("Registo eliminado com sucesso", "Empresa :: Clientes", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'ToDo: limpar textboxes
            End If
        End If

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim cli As New Cliente

        cli.Get_TodosClientes()
        If cli.clienteTabela.Rows.Count <> -1 Then
            Me.DataGridView1.DataSource = cli.clienteTabela
        Else
            MessageBox.Show("Erro!", "Empresa :: Clientes", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    End Sub
End Class
