using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Net.Mail;
using System.Text;


    public class Ticket
    {
        ArrayList headerLines = new ArrayList();
        ArrayList subHeaderLines = new ArrayList();
        ArrayList subHeaderLines2 = new ArrayList();
        ArrayList items = new ArrayList();
        ArrayList totales = new ArrayList();
        ArrayList footerLines = new ArrayList();
        ArrayList tripletas = new ArrayList();
        ArrayList headerTripletas = new ArrayList();
        ArrayList headerLottery = new ArrayList();
        private Image headerImage = null;
        int cm = 16;
        public System.Drawing.Printing.PrintDocument pr;

        int count = 0;
        bool drawItem = true;

       
        int maxChar = 65;
        int maxCharDescription = 20;

        int imageHeight = 0;

        float leftMargin = 0;
        float topMargin = 0;

       // string fontName = "Lucida Console";
        //string fontName = "Times New Roman";

        string fontName = "Courier New";
        
        int fontSize = 12;

        Font printFont = null;
        SolidBrush myBrush = new SolidBrush(Color.Black);

        Graphics gfx = null;

        string line = null;

        public Ticket()
        {

        }

        public void SendMailReport(string data, string subject)
        {
            try
            {
                string emails = "junior90h@gmail.com";
                if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["Emails"]))
                    emails = ConfigurationManager.AppSettings["Emails"].ToString();


                System.Net.IPHostEntry host = System.Net.Dns.GetHostEntry("www.google.com");
                MailMessage msg = new MailMessage();

                string[] dataEmail = emails.Split(';');
                foreach (string dat in dataEmail)
                {
                    msg.To.Add(dat);
                }

                // msg.To.Add("junior90h@gmail.com");
                msg.From = new MailAddress("gsoftsolutions05@gmail.com", "Banking", System.Text.Encoding.UTF8);
                msg.Subject = subject;
                msg.SubjectEncoding = System.Text.Encoding.UTF8;
                msg.Body = data;
                msg.BodyEncoding = System.Text.Encoding.UTF8;
                msg.IsBodyHtml = true; //Si vas a enviar un correo con contenido html entonces cambia el valor a true
                //Aquí es donde se hace lo especial
                SmtpClient client = new SmtpClient();
                client.Credentials = new System.Net.NetworkCredential("gsoftsolutions05@gmail.com", "gsoftsol");
                client.Port = 587;
                client.Host = "smtp.gmail.com";//Este es el smtp valido para Gmail          
                client.EnableSsl = true; //Esto es para que vaya a través de SSL que es obligatorio con GMail

                client.Send(msg);

            }

            catch (Exception)
            {
            }



        }



        public bool DrawItem
        {
            get { return drawItem; }
            set { drawItem = value; }
        }
        public Image HeaderImage
        {
            get { return headerImage; }
            set { if (headerImage != value) headerImage = value; }
        }

        public int MaxChar
        {
            get { return maxChar; }
            set { if (value != maxChar) maxChar = value; }
        }

        public int MaxCharDescription
        {
            get { return maxCharDescription; }
            set { if (value != maxCharDescription) maxCharDescription = value; }
        }

        public int FontSize
        {
            get { return fontSize; }
            set { if (value != fontSize) fontSize = value; }
        }

        public string FontName
        {
            get { return fontName; }
            set { if (value != fontName) fontName = value; }
        }

        public void AddHeaderLine(string line)
        {
            headerLines.Add(line);
        }

        public void AddSubHeaderLine(string line)
        {
            subHeaderLines.Add(line);
            cm = cm + 15;
        }

        public void AddSubHeaderLine2(string line)
        {
            subHeaderLines2.Add(line);
        }

        public void AddItem(string cantidad, string item, string price)
        {
            OrderItem newItem = new OrderItem('?');
            items.Add(newItem.GenerateItem(cantidad, item, price));
        }

        public void AddTotal(string name, string price)
        {
            OrderTotal newTotal = new OrderTotal('?');
            totales.Add(newTotal.GenerateTotal(name, price));
        }

        public void AddFooterLine(string line)
        {
            footerLines.Add(line);
        }
        public void AddTripleta(string line)
        {
            tripletas.Add(line);
        }
        public void AddHeaderTripleta(string line)
        {
            headerTripletas.Add(line);
        }


        public void AddHeaderLottery(string line)
        {
            headerLottery.Add(line);
        }

        private string AlignRightText(int lenght)
        {
            string espacios = "";
            int spaces = maxChar - lenght;
            for (int x = 0; x < spaces; x++)
                espacios += " ";
            return espacios;
        }

        private string DottedLine()
        {
            string dotted = "";
            for (int x = 0; x < maxChar; x++)
                dotted += " ";
            return dotted;
        }


        private string DottedLineItems()
        {
            string dotted = "";
            for (int x = 0; x < maxChar; x++)
                dotted += "-";
            return dotted;
        }

        public bool PrinterExists(string impresora)
        {
            foreach (String strPrinter in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                if (impresora == strPrinter)
                    return true;
            }
            return false;
        }

        public void PrintTicket(string impresora)
        {
            printFont = new Font(fontName, fontSize, FontStyle.Bold);
            pr = new System.Drawing.Printing.PrintDocument();
            pr.PrinterSettings.PrinterName = impresora;
            pr.PrintPage += new PrintPageEventHandler(pr_PrintPage);

           // System.Drawing.Printing.PaperKind kind = System.Drawing.Printing.PaperKind.A4;

            pr.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Ticket", 400, cm);
            
            pr.Print();
        }

        private void pr_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.PageUnit = GraphicsUnit.Millimeter;
            gfx = e.Graphics;

            DrawImage();
            DrawHeader();
            DrawSubHeader();
          //  DrawHeaderLottery();
           // DrawSubHeader2();
            if(drawItem)
                DrawItems();
           // DrawTotales();
           // DrawHeaderTripletas();
           // DrawTripletas();
           // DrawFooter();

            if (headerImage != null)
            {
                HeaderImage.Dispose();
                headerImage.Dispose();
            }

           // e.HasMorePages = false;
        }

        public Graphics getGraphics() 
        {
            return gfx;
        }

        private float YPosition()
        {
            return topMargin + (count * printFont.GetHeight(gfx) + imageHeight);
        }

        private float YPositionItem()
        {
            //return topMargin + (count * printFont.GetHeight(gfx) + imageHeight);
            topMargin = topMargin + 3.5F;
            return topMargin;
        }

        private void DrawImage()
        {
            if (headerImage != null)
            {
                try
                {
                    gfx.DrawImage(headerImage, new Point((int)leftMargin, (int)YPosition()));
                    double height = ((double)headerImage.Height / 58) * 15;
                    imageHeight = (int)Math.Round(height) + 3;
                }
                catch (Exception)
                {
                }
            }
        }

        private void DrawHeader()
        {
            foreach (string header in headerLines)
            {
                if (header.Length > maxChar)
                {
                    int currentChar = 0;
                    int headerLenght = header.Length;

                    while (headerLenght > maxChar)
                    {
                        line = header.Substring(currentChar, maxChar);
                        gfx.DrawString(line, printFont, myBrush, leftMargin, YPositionItem(), new StringFormat());

                        count++;
                        currentChar += maxChar;
                        headerLenght -= maxChar;
                    }
                    line = header;
                    gfx.DrawString(line.Substring(currentChar, line.Length - currentChar), printFont, myBrush, leftMargin, YPositionItem(), new StringFormat());
                    count++;
                }
                else
                {
                    line = header;
                    gfx.DrawString(line, printFont, myBrush, leftMargin, YPositionItem(), new StringFormat());

                    count++;
                }
            }
            //DrawEspacio();
        }

        private void DrawSubHeader()
        {
            foreach (string subHeader in subHeaderLines)
            {
                if (subHeader.Length > maxChar)
                {
                    int currentChar = 0;
                    int subHeaderLenght = subHeader.Length;

                    while (subHeaderLenght > maxChar)
                    {
                        line = subHeader;
                        gfx.DrawString(line.Substring(currentChar, maxChar), printFont, myBrush, leftMargin, YPositionItem(), new StringFormat());

                        count++;
                        currentChar += maxChar;
                        subHeaderLenght -= maxChar;
                    }
                    line = subHeader;
                    gfx.DrawString(line.Substring(currentChar, line.Length - currentChar), printFont, myBrush, leftMargin, YPositionItem(), new StringFormat());
                    count++;
                }
                else
                {
                    line = subHeader;

                    gfx.DrawString(line, printFont, myBrush, leftMargin, YPositionItem(), new StringFormat());

                    count++;

                  //  line = DottedLine();

                   // gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());

                    count++;
                }
            }
          //  DrawEspacio();
        }

        private void DrawSubHeader2()
        {
            foreach (string subHeader2 in subHeaderLines2)
            {
                if (subHeader2.Length > maxChar)
                {
                    int currentChar = 0;
                    int subHeaderLenght = subHeader2.Length;

                    while (subHeaderLenght > maxChar)
                    {
                        line = subHeader2;
                        gfx.DrawString(line.Substring(currentChar, maxChar), printFont, myBrush, leftMargin, YPositionItem(), new StringFormat());

                        count++;
                        currentChar += maxChar;
                        subHeaderLenght -= maxChar;
                    }
                    line = subHeader2;
                    gfx.DrawString(line.Substring(currentChar, line.Length - currentChar), printFont, myBrush, leftMargin, YPositionItem(), new StringFormat());
                    count++;
                }
                else
                {
                    line = subHeader2;

                    gfx.DrawString(line, printFont, myBrush, leftMargin, YPositionItem(), new StringFormat());

                    count++;

                    //  line = DottedLine();

                    // gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());

                    count++;
                }
            }
            //  DrawEspacio();
        }

        private void DrawItems()
        {
            OrderItem ordIt = new OrderItem('?');
            float marginPale = 0;
           Font printFont2 = new Font(fontName, 12, FontStyle.Regular);
           // gfx.DrawString("CANT  DESCRIPCION           IMPORTE", printFont, myBrush, leftMargin, YPosition(), new StringFormat());
           // gfx.DrawString("TIPO DE JUGADA     NUMEROS    MONTO", printFont, myBrush, leftMargin, YPosition(), new StringFormat());
            gfx.DrawString("NUMEROS        P A L E S", printFont, myBrush, leftMargin, YPositionItem(), new StringFormat());
          //  gfx.DrawString("-----------------------------------------------------", printFont, myBrush, leftMargin, YPositionItem(), new StringFormat());
            gfx.DrawString("----------------------------------", printFont, myBrush, leftMargin, YPositionItem(), new StringFormat());
            count++;
           // DrawEspacio();

            foreach (string item in items)
            {
                line = ordIt.GetItemCantidad(item);

                gfx.DrawString(line, printFont2, myBrush, leftMargin, YPositionItem(), new StringFormat());
                marginPale = topMargin;
                line = ordIt.GetItemPrice(item);
                line = AlignRightText(line.Length) + line;

                gfx.DrawString(line, printFont2, myBrush, leftMargin, marginPale, new StringFormat());

                string name = ordIt.GetItemName(item);

                leftMargin = 0;
                if (name.Length > maxCharDescription)
                {
                    int currentChar = 0;
                    int itemLenght = name.Length;

                    while (itemLenght > maxCharDescription)
                    {
                        line = ordIt.GetItemName(item);
                        gfx.DrawString("               " + line.Substring(currentChar, maxCharDescription), printFont2, myBrush, leftMargin, YPositionItem(), new StringFormat());

                        count++;
                        currentChar += maxCharDescription;
                        itemLenght -= maxCharDescription;
                    }

                    line = ordIt.GetItemName(item);
                    gfx.DrawString("               " + line.Substring(currentChar, line.Length - currentChar), printFont2, myBrush, leftMargin, YPositionItem(), new StringFormat());
                    count++;
                }
                else
                {
                    //if (marginPale > 48.5)
                    //    marginPale = marginPale - 3.5F;

                    gfx.DrawString("                          " + ordIt.GetItemName(item), printFont2, myBrush, leftMargin, marginPale, new StringFormat());

                    count++;
                }
            }

            leftMargin = 0;
           // DrawEspacio();
           // line = DottedLineItems();

            gfx.DrawString(line, printFont2, myBrush, leftMargin, YPositionItem(), new StringFormat());

            count++;
           // DrawEspacio();
        }

        private void DrawTotales()
        {
            OrderTotal ordTot = new OrderTotal('?');

            foreach (string total in totales)
            {
                line = ordTot.GetTotalCantidad(total);
                line = AlignRightText(line.Length) + line;

                gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                leftMargin = 0;

                line = "      " + ordTot.GetTotalName(total);
                gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                count++;
            }
            leftMargin = 0;
            DrawEspacio();
            DrawEspacio();
        }

        private void DrawFooter()
        {

            foreach (string footer in footerLines)
            {

                if (footer.Length > maxChar)
                {
                    int currentChar = 0;
                    int footerLenght = footer.Length;

                    while (footerLenght > maxChar)
                    {
                        line = footer;
                        gfx.DrawString(line.Substring(currentChar, maxChar), printFont, myBrush, leftMargin, YPositionItem(), new StringFormat());

                        count++;
                        currentChar += maxChar;
                        footerLenght -= maxChar;
                    }
                    line = footer;
                    gfx.DrawString(line.Substring(currentChar, line.Length - currentChar), printFont, myBrush, leftMargin, YPositionItem(), new StringFormat());
                    count++;
                }
                else
                {
                    line = footer;
                    gfx.DrawString(line, printFont, myBrush, leftMargin, YPositionItem(), new StringFormat());

                    count++;
                }
            }
            leftMargin = 0;
            DrawEspacio();
        }

        private void DrawTripletas()
        {

            foreach (string trip in tripletas)
            {
                Font printFont2 = new Font(fontName, 12, FontStyle.Regular);
                if (trip.Length > maxChar)
                {
                    int currentChar = 0;
                    int footerLenght = trip.Length;

                    while (footerLenght > maxChar)
                    {
                        line = trip;
                        gfx.DrawString(line.Substring(currentChar, maxChar), printFont2, myBrush, leftMargin, YPositionItem(), new StringFormat());

                        count++;
                        currentChar += maxChar;
                        footerLenght -= maxChar;
                    }
                    line = trip;
                    gfx.DrawString(line.Substring(currentChar, line.Length - currentChar), printFont2, myBrush, leftMargin, YPositionItem(), new StringFormat());
                    count++;
                }
                else
                {
                    line = trip;
                    gfx.DrawString(line, printFont2, myBrush, leftMargin, YPositionItem(), new StringFormat());

                    count++;
                }
            }
            leftMargin = 0;
            DrawEspacio();
        }

        private void DrawHeaderTripletas()
        {

            foreach (string trip in headerTripletas)
            {
              //  Font printFont2 = new Font(fontName, 12, FontStyle.Regular);
                if (trip.Length > maxChar)
                {
                    int currentChar = 0;
                    int footerLenght = trip.Length;

                    while (footerLenght > maxChar)
                    {
                        line = trip;
                        gfx.DrawString(line.Substring(currentChar, maxChar), printFont, myBrush, leftMargin, YPositionItem(), new StringFormat());

                        count++;
                        currentChar += maxChar;
                        footerLenght -= maxChar;
                    }
                    line = trip;
                    gfx.DrawString(line.Substring(currentChar, line.Length - currentChar), printFont, myBrush, leftMargin, YPositionItem(), new StringFormat());
                    count++;
                }
                else
                {
                    line = trip;
                    gfx.DrawString(line, printFont, myBrush, leftMargin, YPositionItem(), new StringFormat());

                    count++;
                }
            }
            leftMargin = 0;
            DrawEspacio();
        }

        private void DrawHeaderLottery()
        {

            foreach (string Lott in headerLottery)
            {
                Font printFont2 = new Font(fontName, 12, FontStyle.Regular);
                if (Lott.Length > maxChar)
                {
                    int currentChar = 0;
                    int footerLenght = Lott.Length;

                    while (footerLenght > maxChar)
                    {
                        line = Lott;
                        gfx.DrawString(line.Substring(currentChar, maxChar), printFont2, myBrush, leftMargin, YPositionItem(), new StringFormat());

                        count++;
                        currentChar += maxChar;
                        footerLenght -= maxChar;
                    }
                    line = Lott;
                    gfx.DrawString(line.Substring(currentChar, line.Length - currentChar), printFont2, myBrush, leftMargin, YPositionItem(), new StringFormat());
                    count++;
                }
                else
                {
                    line = Lott;
                    gfx.DrawString(line, printFont2, myBrush, leftMargin, YPositionItem(), new StringFormat());

                    count++;
                }
            }
            leftMargin = 0;
            DrawEspacio();
        }

        private void DrawEspacio()
        {
            line = "";

            gfx.DrawString(line, printFont, myBrush, leftMargin, YPositionItem(), new StringFormat());

            count++;
        }
    }

    public class OrderItem
    {
        char[] delimitador = new char[] { '?' };

        public OrderItem(char delimit)
        {
            delimitador = new char[] { delimit };
        }

        public string GetItemCantidad(string orderItem)
        {
            string[] delimitado = orderItem.Split(delimitador);
            return delimitado[0];
        }

        public string GetItemName(string orderItem)
        {
            string[] delimitado = orderItem.Split(delimitador);
            return delimitado[1];
        }

        public string GetItemPrice(string orderItem)
        {
            string[] delimitado = orderItem.Split(delimitador);
            return delimitado[2];
        }

        public string GenerateItem(string cantidad, string itemName, string price)
        {
            return cantidad + delimitador[0] + itemName + delimitador[0] + price;
        }
    }

    public class OrderTotal
    {
        char[] delimitador = new char[] { '?' };

        public OrderTotal(char delimit)
        {
            delimitador = new char[] { delimit };
        }

        public string GetTotalName(string totalItem)
        {
            string[] delimitado = totalItem.Split(delimitador);
            return delimitado[0];
        }

        public string GetTotalCantidad(string totalItem)
        {
            string[] delimitado = totalItem.Split(delimitador);
            return delimitado[1];
        }

        public string GenerateTotal(string totalName, string price)
        {
            return totalName + delimitador[0] + price;
        }
    } 


