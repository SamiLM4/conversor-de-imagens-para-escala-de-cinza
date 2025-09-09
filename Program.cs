using System;
using System.Drawing;
using System.IO;
/*
*Colegio Técnico Antônio Teixeira Fernandes (Univap)
 *Curso Técnico em Informática - Data de Entrega: 09 / 09 / 2025
* Autores do Projeto: Murilo Gonçalves de Lima
*
* Turma: 2M
* Atividade Proposta em aula
 * Observação: < colocar se houver>
 * 
 * 
 * ******************************************************************/

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Digite o caminho completo da imagem (ex: C:\\imagens\\foto.jpg):");
        string caminho = Console.ReadLine();

        try
        {
            ImgGrayLevel(caminho);
            Console.WriteLine("Imagem convertida para tons de cinza com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao processar a imagem: " + ex.Message);
        }
    }

    public static void ImgGrayLevel(string img)
    {
        if (!File.Exists(img))
        {
            throw new FileNotFoundException("Arquivo não encontrado: " + img);
        }

        using (Bitmap bitmap = new Bitmap(img))
        {
            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    Color original = bitmap.GetPixel(x, y);
                    int gray = (int)(original.R * 0.3 + original.G * 0.59 + original.B * 0.11);
                    gray = Math.Clamp(gray, 0, 255);
                    Color grayColor = Color.FromArgb(gray, gray, gray);
                    bitmap.SetPixel(x, y, grayColor);
                }
            }

            string dir = Path.GetDirectoryName(img);
            string name = Path.GetFileNameWithoutExtension(img);
            string ext = Path.GetExtension(img);
            string newPath = Path.Combine(dir, $"{name}_gray{ext}");

            bitmap.Save(newPath);
        }
    }
}
