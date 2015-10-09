Public Class MailingBLL
    Public Shared Sub enviarNewsletter(ByVal _paramBoletin As Entidades.Boletin)
        Try
            Dim Correo As New System.Net.Mail.MailMessage()
            Correo.IsBodyHtml = True
            Correo.From = New System.Net.Mail.MailAddress("ALEXIS.TAKUMI@gmail.com", "Shigami Anime Store")
            For Each UsuarioDestino As Entidades.Usuario In _paramBoletin.Suscriptores
                Correo.To.Add(UsuarioDestino.Correo)
            Next
            Correo.Subject = _paramBoletin.Nombre
            Correo.Body = "<html><head></head><body><img src=""http://newshour-tc.pbs.org/newshour/wp-content/uploads/2014/08/Testing.jpg"" /><b>Alexis Yañez - Boletin</b></body></html> "
            Correo.Priority = System.Net.Mail.MailPriority.Normal
            Dim smtp As New System.Net.Mail.SmtpClient
            smtp.Host = "smtp.gmail.com"
            smtp.Port = 587
            smtp.Credentials = New System.Net.NetworkCredential("ALEXIS.TAKUMI@gmail.com", EncriptarBLL.Desencriptar("4C45C98580658365FF5475623671959F"))
            smtp.EnableSsl = True
            smtp.Send(Correo)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Shared Sub enviarMailRecupero(ByVal _paramUsuario As Entidades.Usuario, passgenerada As String)
        Try
            Dim Correo As New System.Net.Mail.MailMessage()
            Correo.IsBodyHtml = True
            Correo.From = New System.Net.Mail.MailAddress("ALEXIS.TAKUMI@gmail.com", "Shigami Anime Store")
            Correo.To.Add(_paramUsuario.Persona.Mail)
            Correo.Subject = "Shigami Anime Store - Recupero de Contraseña"
            Correo.Body = "<html><head> </head><body><img src=""http://i61.tinypic.com/2moqwb4.png"" width=""50px"" height=""50px"" /><b> " & _
            " Recupero de Contraseña</b><hr " & _
            " style=""border-style: 0; border-color: 0; border-width: 0px; padding: 0px; margin: 0px; height: 7px; background-color: #019098;"" /> " & _
            " <br /> <br /><span><b> Estimado Sr/a: " & _paramUsuario.Persona.Nombre & " " & _paramUsuario.Persona.Apellido & ": <br/> Se envía su nueva contraseña para acceder con su usuario " & _paramUsuario.NombreUsuario & " en nuestro sistema. <br />Su nueva clave de acceso es <strong>" & passgenerada & "</strong>. Por favor, no olvide cambiar la misma al ingresar al Sistema. <br/> Saluda Atte. <br/><br/> Shigami Anime Store <br/>  </span><p>  &nbsp;</p><p>   &nbsp;</p><hr " & _
            "style=""border-style: 0; border-color: 0; border-width: 0px; padding: 0px; margin: 0px; height: 7px; background-color: #019098;"" /> " & _
            " </body></html> "
            Correo.Priority = System.Net.Mail.MailPriority.Normal
            Dim smtp As New System.Net.Mail.SmtpClient
            smtp.Host = "smtp.gmail.com"
            smtp.Port = 587
            smtp.Credentials = New System.Net.NetworkCredential("ALEXIS.TAKUMI@gmail.com", EncriptarBLL.Desencriptar("4C45C98580658365FF5475623671959F"))
            smtp.EnableSsl = True
            smtp.Send(Correo)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Shared Sub enviarMailBloqueado(ByVal _paramUsuario As Entidades.Usuario)
        Try
            Dim Correo As New System.Net.Mail.MailMessage()
            Correo.IsBodyHtml = True
            Correo.From = New System.Net.Mail.MailAddress("ALEXIS.TAKUMI@gmail.com", "Shigami Anime Store")
            Correo.To.Add(_paramUsuario.Correo)
            Correo.Subject = "Shigami Anime Store - Usuario Bloqueado"
            Correo.Body = "<html><head> </head><body><img src=""http://i61.tinypic.com/2moqwb4.png"" width=""50px"" height=""50px"" /><b> " & _
            " Usuario Bloqueado</b><hr " & _
            " style=""border-style: 0; border-color: 0; border-width: 0px; padding: 0px; margin: 0px; height: 7px; background-color: #003366;"" /> " & _
            " <br /> <br /><span><b> Estimado Sr/a " & _paramUsuario.Persona.Nombre & " " & _paramUsuario.Persona.Apellido & " el usuario  " & _paramUsuario.NombreUsuario & " fue Bloqueado por razones de Seguridad. Para activarlo nuevamente comuniquese con el Administrador.<br/> Saluda Atte. <br/><br/> Shigami Anime Store <br/></span><p>  &nbsp;</p><p>   &nbsp;</p><hr " & _
            "style=""border-style: 0; border-color: 0; border-width: 0px; padding: 0px; margin: 0px; height: 7px; background-color: #003366;"" /> " & _
            " </body></html> "
            Correo.Priority = System.Net.Mail.MailPriority.Normal
            Dim smtp As New System.Net.Mail.SmtpClient
            smtp.Host = "smtp.gmail.com"
            smtp.Port = 587
            smtp.Credentials = New System.Net.NetworkCredential("ALEXIS.TAKUMI@gmail.com", EncriptarBLL.Desencriptar("4C45C98580658365FF5475623671959F"))
            smtp.EnableSsl = True
            smtp.Send(Correo)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Public Shared Sub enviarMailRegistroUsuario(ByVal _paramUsuario As Entidades.Usuario, ByVal passgenerada As String)
        Try
            Dim Correo As New System.Net.Mail.MailMessage()
            Correo.IsBodyHtml = True
            Correo.From = New System.Net.Mail.MailAddress("ALEXIS.TAKUMI@gmail.com", "Shigami Anime Store")
            Correo.To.Add(_paramUsuario.Correo)
            Correo.Subject = "Shigami Anime Store - Registro de Usuario"
            Correo.Body = "<html><head> </head><body><img src=""http://i61.tinypic.com/2moqwb4.png"" width=""50px"" height=""50px"" /><b> " & _
            " Registro de Usuario</b><hr " & _
            " style=""border-style: 0; border-color: 0; border-width: 0px; padding: 0px; margin: 0px; height: 7px; background-color: #019098;"" /> " & _
            " <br /> <br /><span><b> Estimado Sr/a: " & _paramUsuario.Persona.Nombre & " " & _paramUsuario.Persona.Apellido & ": <br/> Se registró al nuevo usuario  " & _paramUsuario.NombreUsuario & " en nuestro sistema. <br />Su clave de acceso es <strong>" & passgenerada & "</strong>. Por favor, no olvide cambiar la misma al ingresar al Sistema. <br/> Saluda Atte. <br/><br/> Shigami Anime Store <br/>  </span><p>  &nbsp;</p><p>   &nbsp;</p><hr " & _
            "style=""border-style: 0; border-color: 0; border-width: 0px; padding: 0px; margin: 0px; height: 7px; background-color: #019098;"" /> " & _
            " </body></html> "
            Correo.Priority = System.Net.Mail.MailPriority.Normal
            Dim smtp As New System.Net.Mail.SmtpClient
            smtp.Host = "smtp.gmail.com"
            smtp.Port = 587
            smtp.Credentials = New System.Net.NetworkCredential("ALEXIS.TAKUMI@gmail.com", EncriptarBLL.Desencriptar("4C45C98580658365FF5475623671959F"))
            smtp.EnableSsl = True
            smtp.Send(Correo)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Public Shared Sub enviarMailRespuesta(ByVal paramContacto As Entidades.Contacto)
        Try
            Dim Correo As New System.Net.Mail.MailMessage()
            Correo.IsBodyHtml = True
            Correo.From = New System.Net.Mail.MailAddress("ALEXIS.TAKUMI@gmail.com", "Shigami Anime Store")
            Correo.To.Add(paramContacto.Mail)
            Correo.Subject = "Shigami Anime Store - Respuesta a Consulta"
            Correo.Body = "<html><head> </head><body><img src=""http://i61.tinypic.com/2moqwb4.png"" width=""50px"" height=""50px"" /><b> " & _
            " Respuesta a Consulta</b><hr " & _
            " style=""border-style: 0; border-color: 0; border-width: 0px; padding: 0px; margin: 0px; height: 7px; background-color: #019098;"" /> " & _
            " <br /> <br /><span><b> Estimado Sr/a: " & paramContacto.NombreCompleto & ": <br/> Procedemos a contestar la Consulta que realizó mediante nuestro Portal Web <br/><br/> <u>Su Consulta:</u> <br/> " & paramContacto.Mensaje & " <br/><br/> <u>Nuestra Respuesta:</u><br/>" & paramContacto.Respuesta & " <br/> Le Agradecemos su participación. <br/> Saluda Atte. <br/><br/> Shigami Anime Store <br/></span><p>  &nbsp;</p><p>   &nbsp;</p><hr " & _
            "style=""border-style: 0; border-color: 0; border-width: 0px; padding: 0px; margin: 0px; height: 7px; background-color: #019098;"" /> " & _
            " </body></html> "
            Correo.Priority = System.Net.Mail.MailPriority.Normal
            Dim smtp As New System.Net.Mail.SmtpClient
            smtp.Host = "smtp.gmail.com"
            smtp.Port = 587
            smtp.Credentials = New System.Net.NetworkCredential("ALEXIS.TAKUMI@gmail.com", EncriptarBLL.Desencriptar("4C45C98580658365FF5475623671959F"))
            smtp.EnableSsl = True
            smtp.Send(Correo)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


End Class
