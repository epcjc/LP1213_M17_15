Imports System.Data.SqlClient

Public Class Cliente
    Private m_ArtigoID As Integer
    Private m_Titulo As String
    Private m_Autor As String
    Private m_data As String
    Private m_Texto As String
    Private m_Palavra As String

   
    Private m_erro As Boolean

    Public clienteTabela As New DataTable

    Public Property ArtigoID() As Integer
        Get
            Return m_ArtigoID
        End Get
        Set(ByVal value As Integer)
            m_ArtigoID = value
        End Set
    End Property

    Public Property nome() As String
        Get
            Return m_Titulo
        End Get
        Set(ByVal value As String)
            m_Titulo = value
        End Set
    End Property

    Public Property morada() As String
        Get
            Return m_Autor
        End Get
        Set(ByVal value As String)
            m_Autor = value
        End Set
    End Property


    Public Property codPostal() As String
        Get
            Return m_data
        End Get
        Set(ByVal value As String)
            m_data = value
        End Set
    End Property

    Public Property cidade() As String
        Get
            Return m_Texto
        End Get
        Set(ByVal value As String)
            m_Texto = value
        End Set
    End Property

    Public Property telefone() As String
        Get
            Return m_Palavra
        End Get
        Set(ByVal value As String)
            m_Palavra = value
        End Set
    End Property

    Public Property erro()
        Get
            Return m_erro
        End Get
        Set(ByVal value)
            m_erro = value
        End Set
    End Property


    Public Sub Get_Cliente(ByVal clienteNome As String)
        erro = False

        Dim connString As String
        Dim conn As SqlConnection

        connString = "Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True;User Instance=True"
        conn = New SqlConnection(connString)

        Dim cmd As New SqlCommand
        Dim reader As SqlDataReader

        With cmd
            .Connection = conn
            .CommandTimeout = 5
            .CommandText = "SELECT * FROM Artigos WHERE titulo='" & & "'"
            .CommandType = CommandType.Text
        End With

        Try
            conn.Open()
            reader = cmd.ExecuteReader

            If reader.HasRows Then
                reader.Read()
                If Not IsDBNull(reader.Item("ArtigoID")) Then
                    ArtigoID = reader.Item("ArtigoID")
                End If
                If Not IsDBNull(reader.Item("Titulo")) Then
                    nome = reader.Item("Titulo")
                End If
                If Not IsDBNull(reader.Item("Autor")) Then
                    morada = reader.Item("Autor")
                End If
                If Not IsDBNull(reader.Item("Data")) Then
                    codPostal = reader.Item("Data")
                End If
                If Not IsDBNull(reader.Item("Texto")) Then
                    cidade = reader.Item("Texto ")
                End If
                If Not IsDBNull(reader.Item("Palavra")) Then
                    telefone = reader.Item("Palavra")
                End If
            Else
                'ArtigoID = 0
            End If


            'While reader.Read
            '    If Not IsDBNull(reader.Item("ArtigoID")) Then
            '        clienteID = reader.Item("ArtigoID")
            '    End If
            '    If Not IsDBNull(reader.Item("Titulo")) Then
            '        nome = reader.Item("Titulo")
            '    End If
            '    If Not IsDBNull(reader.Item("Autor")) Then
            '        morada = reader.Item("Autor")
            '    End If
            '    If Not IsDBNull(reader.Item("Data")) Then
            '        codPostal = reader.Item("Data")
            '    End If
            '    If Not IsDBNull(reader.Item("Texto")) Then
            '        cidade = reader.Item("Texto")
            '    End If
            '    If Not IsDBNull(reader.Item("Palavra")) Then
            '        telefone = reader.Item("Palavra")
            '    End If
            'End Whil

        Catch ex As Exception
            erro = True
            If ConnectionState.Open Then
                conn.Close()
            End If
        Finally
            conn.Close()
        End Try
    End Sub

    Public Sub Get_TodosClientes()
        erro = False

        Dim connString As String
        Dim conn As SqlConnection

        connString = "Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database11.mdf;Integrated Security=True;User Instance=True"
        conn = New SqlConnection(connString)

        Dim cmd As New SqlCommand
        Dim adapter As New SqlDataAdapter

        Try
            conn.Open()
            With cmd
                .Connection = conn
                .CommandTimeout = 5
                .CommandText = "SELECT * FROM artigos"
                .CommandType = CommandType.Text
            End With

            clienteTabela.Clear()
            cmd.ExecuteNonQuery()

            adapter.SelectCommand = cmd
            adapter.Fill(clienteTabela)
        Catch ex As Exception
            If ConnectionState.Open Then
                conn.Close()
            End If
        Finally
            conn.Close()
        End Try
    End Sub

    Public Sub novoArtigo(ByVal titulo As String, ByVal autor As String, _
    ByVal data As String, ByVal texto As String, ByVal palavra As String)
        erro = False
        Dim connString As String
        Dim conn As SqlConnection

        connString = "Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True;User Instance=True"
        conn = New SqlConnection(connString)

        Dim cmd As New SqlCommand
        Dim SQL As String = "INSERT INTO Artigos(ArtigoID, Titulo, Autor, Data, Texto)" & _
                            "VALUES(@ArtigoID, @Titulo, @autor, @Data, @Texto)"
        Try
            conn.Open()
            With cmd
                .Connection = conn
                .CommandTimeout = 5
                .CommandText = SQL
                .CommandType = CommandType.Text
                .Parameters.Add(New SqlParameter("@titulo", SqlDbType.VarChar, 50))
                .Parameters("@titulo").Value = titulo
                .Parameters.Add(New SqlParameter("@autor", SqlDbType.VarChar, 50))
                .Parameters("@autor").Value = autor
                .Parameters.Add(New SqlParameter("@data", SqlDbType.VarChar, 50))
                .Parameters("@data").Value = data
                .Parameters.Add(New SqlParameter("@texto", SqlDbType.VarChar, 50))
                .Parameters("@texto").Value = texto
                .Parameters.Add(New SqlParameter("@palavra", SqlDbType.VarChar, 50))
                .Parameters("@palavra").Value = palavra
            End With

            cmd.ExecuteNonQuery()

        Catch ex As Exception
            erro = True
        Finally
            conn.Close()
        End Try
    End Sub

    Public Sub eliminarRegisto(ByVal clienteCod As Integer)
        erro = False

        Dim connString As String
        Dim conn As SqlConnection

        connString = "Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True;User Instance=True"
        conn = New SqlConnection(connString)

        Dim cmd As New SqlCommand

        With cmd
            .Connection = conn
            .CommandTimeout = 5
            .CommandText = "DELETE FROM Artigos WHERE ArtigoID='" & & "'"
            .CommandType = CommandType.Text
        End With

        Try
            conn.Open()
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            erro = True
        Finally
            conn.Close()
        End Try


    End Sub

    Sub eliminarCliente(ByVal p1 As String)
        Throw New NotImplementedException
    End Sub

End Class
