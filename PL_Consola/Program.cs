ReadFile();
Console.ReadKey();

static void ReadFile()
{
    string file = @"C:\Users\digis\Desktop\datos.txt";

    if (File.Exists(file))
    {
        StreamReader Textfile = new StreamReader(file);

        string line;
        line = Textfile.ReadLine();
        while ((line = Textfile.ReadLine()) != null)
        {
            string[] lines = line.Split(",");

            ML.Empleado empleado = new ML.Empleado();

            empleado.NumeroEmpleado = lines[0];
            empleado.RFC = lines[1];
            empleado.Nombre = lines[2];
            empleado.ApellidoPaterno = lines[3];
            empleado.ApellidoMaterno = lines[4];
            empleado.Email = lines[5];
            empleado.Telefono = lines[6];
            empleado.FechaNacimiento = lines[7];
            empleado.NSS = lines[8];
            empleado.Foto = "";

            empleado.Empresa = new ML.Empresa();
            empleado.Empresa.IdEmpresa = int.Parse(lines[10]);


            ML.Result result = BL.Empleado.Add(empleado);

            if (result.Correct)
            {
                Console.WriteLine("Se inserto el registro");
                Console.ReadKey();
            }
            else
            {
                string fileError = @"C:\Users\digis\Desktop\Error.txt";
                string texto = "Error al insertar las filas " + result.Ex;

                using (StreamWriter errorFile = new StreamWriter(fileError))
                {
                    errorFile.WriteLine(texto);
                    errorFile.Close();
                }
            }
        }
    }
}