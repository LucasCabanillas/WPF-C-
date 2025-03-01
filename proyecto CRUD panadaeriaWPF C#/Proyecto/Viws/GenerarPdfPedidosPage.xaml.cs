using System;
using System.Data;
using System.IO;
using System.Windows;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Kernel.Font;  // Asegúrate de tener este using para PdfFont
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Pdf.Canvas.Draw;
using Proyecto.Clases;
using MySql.Data.MySqlClient;
using System.Windows.Documents;
using System.Windows.Forms; // Para el SaveFileDialog
using iTextTable = iText.Layout.Element.Table;  // Alias para iText.Table
using iTextTextAlignment = iText.Layout.Properties.TextAlignment;  // Alias para iText.TextAlignment
using Document = iText.Layout.Document;
using MySqlX.XDevAPI.Relational;
using iText.Kernel.Geom; // Alias para evitar la ambigüedad
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System.Diagnostics;
using PdfSharpPdfDocument = PdfSharp.Pdf.PdfDocument;
using PdfSharpPdfPage = PdfSharp.Pdf.PdfPage;
using PdfSharpXGraphics = PdfSharp.Drawing.XGraphics;
// Alias para evitar conflicto con la clase Paragraph de WPF
using iTextParagraph = iText.Layout.Element.Paragraph;
using iTextPdfDocument = iText.Kernel.Pdf.PdfDocument;
using iTextPdfPage = iText.Kernel.Pdf.PdfPage;
using iTextXGraphics = iText.Layout.Canvas;
using System.Text;
using System;

namespace Proyecto.Viws
{
    public partial class GenerarPdfPedidosPage
    {
        private Conexion conexion = new Conexion();
        public GenerarPdfPedidosPage()
        {
            InitializeComponent();
        }
        public void CrearPDF()
        {
            // Registrar el proveedor de codificación para evitar el error de codificación
            Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            
            // Crear una ruta válida en la carpeta de Documentos del usuario
        string carpetaDocumentos = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string rutaArchivo = System.IO.Path.Combine(carpetaDocumentos, "mi_archivo.pdf");
            // Crear el escritor de PDF
            using (PdfWriter writer = new PdfWriter(rutaArchivo))
            {
                // Crear el documento PDF
                using (iTextPdfDocument pdf = new iTextPdfDocument(writer))
                {
                    // Crear una instancia de Document (equivalente a una página)
                    Document document = new Document(pdf);

                    // Escribir el texto "Hola a todos"
                    document.Add(new iTextParagraph("Hola a todos"));

                    // Cerrar el documento (esto guarda el PDF)
                    document.Close();
                }
            }

            // Abrir el PDF con la aplicación predeterminada
            Process.Start(new ProcessStartInfo(rutaArchivo) { UseShellExecute = true });
        }
        
        private void btnGenerarPDF_Click(object sender, RoutedEventArgs e)
        {
            CrearPDF();
        }

    }
}