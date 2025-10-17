using InventoryDataService;
using System;
using System.Collections.Generic;
using System.Linq;
using MailKit.Net.Smtp;
using MimeKit;
using static System.Net.Mime.MediaTypeNames;

namespace InventoryBusinessDataLogic
{
    public class EmailService
    {
        public void SendEmail(string number = "unknown")
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("CharmBeads.alih Inventory", "do-not-reply@atm.com"));
            message.To.Add(new MailboxAddress("Account Owner", "user@example.com"));
            message.Subject = "Updated Inventory";
            message.Body = new TextPart("plain");

            string htmlBody = @"
<!doctype html>
<html>
  <head>
    <meta http-equiv='Content-Type' content='text/html; charset=UTF-8'>
    <title>Bead Inventory Updated</title>
  </head>
  <body style='margin:0; padding:0; background-color:#fef6fb; font-family: ""Segoe UI"", Arial, sans-serif;'>

    <div style='max-width:600px; margin:40px auto; background-color:#ffffff; border-radius:12px; box-shadow:0 4px 12px rgba(0,0,0,0.1); overflow:hidden;'>

      <!-- Header -->
      <div style='background:linear-gradient(135deg, #e0aaff, #fcb3e1); padding:25px; text-align:center;'>
        <h1 style='color:#ffffff; font-size:24px; margin:0;'>💎 Bead Inventory Update 💎</h1>
      </div>

      <!-- Body -->
      <div style='padding:30px; color:#4b4453; text-align:center;'>
        <p style='font-size:18px; margin-top:0;'>Hi there, bead lover! 💖</p>
        <p style='font-size:16px; line-height:1.6;'>
          Your bead inventory has just been <strong>updated successfully</strong>! 🎀<br>
          Here’s the latest sparkle in your collection:
        </p>

        <img
          src='https://cdn-icons-png.flaticon.com/512/815/815530.png'
          alt='Cute Beads'
          style='width:80px; margin:25px auto; display:block;'
        >

        <p style='font-size:16px; line-height:1.6;'>
          Keep shining and crafting your beautiful creations! ✨<br>
          Your inventory is always up to date.
        </p>

      </div>

      <!-- Footer -->
      <div style='background-color:#fdf2fa; text-align:center; padding:15px; font-size:12px; color:#888;'>
        © 2025 CharmBeads.alih 💕 — Bringing sparkle to every creation
      </div>

    </div>
  </body>
</html>
";


            message.Body = new TextPart("html")
            {
                Text = htmlBody
            };


            using (var client = new SmtpClient())
                {
                    var smtpHost = "sandbox.smtp.mailtrap.io";
                    var smtpPort = 2525;
                    var tls = MailKit.Security.SecureSocketOptions.StartTls;

                    client.Connect(smtpHost, smtpPort, tls);

                    var userName = "e5cf197f5c9ed9";
                    var password = "469dc22d8ab1cd";

                    client.Authenticate(userName, password);
                    client.Send(message);
                    client.Disconnect(true);
                }
            }
        }
    }

 
