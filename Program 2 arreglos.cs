using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_1
{
    class Trabajador
    {
        // Propiedades de la clase Trabajador
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public int Categoria { get; set; }
        public double TarifaHora { get; set; }
        public int HorasLaboradas { get; set; }
        public double SueldoBase { get; set; }
        public double Incremento { get; set; }
        public double SueldoBruto { get; set; }
        public double RetencionCCSS { get; set; }
        public double SueldoNeto { get; set; }

        // Constructor de la clase Trabajador
        public Trabajador(string identificacion, string nombre, int categoria, double tarifaHora, int horasLaboradas)
        {
            // Inicialización de propiedades
            Identificacion = identificacion;
            Nombre = nombre;
            Categoria = categoria;
            TarifaHora = tarifaHora;
            HorasLaboradas = horasLaboradas;

            // Llamada al método para calcular el sueldo
            CalcularSueldo();
        }

        // Método privado para calcular el sueldo del trabajador
        private void CalcularSueldo()
        {
            // Cálculo del sueldo base
            SueldoBase = TarifaHora * HorasLaboradas;

            // Cálculo del incremento según la categoría del trabajador
            switch (Categoria)
            {
                case 1: // Operador
                    Incremento = SueldoBase * 0.15;
                    break;
                case 2: // Técnico
                    Incremento = SueldoBase * 0.10;
                    break;
                case 3: // Profesional
                    Incremento = SueldoBase * 0.05;
                    break;
                default:
                    Incremento = 0;
                    break;
            }

            // Cálculo del sueldo bruto, retención de la CCSS y sueldo neto
            SueldoBruto = SueldoBase + Incremento;
            RetencionCCSS = SueldoBruto * 0.0917; // 9.17% de retención por CCSS
            SueldoNeto = SueldoBruto - RetencionCCSS;
        }

        // Sobrecarga del método ToString para mostrar los detalles del trabajador
        public override string ToString()
        {
            return $"Identificacion: {Identificacion}\nNombre Trabajador: {Nombre}\nCategoria Trabajador: {Categoria}\nTarifa por Hora: {TarifaHora}\nHoras Laboradas: {HorasLaboradas}\nSueldo Base: {SueldoBase}\nIncremento: {Incremento}\nSueldo Bruto: {SueldoBruto}\nRetención CCSS: {RetencionCCSS}\nSueldo Neto: {SueldoNeto}\n";
        }
    }

    internal class Programa
    {
        static void Main(string[] args)
        {
            // Inicio del programa
            // Crear una lista para almacenar los trabajadores
            List<Trabajador> trabajadores = new List<Trabajador>();
            int opcion;

            // Bucle para ingresar datos de trabajadores
            do
            {
                Console.WriteLine("Ingrese los datos del trabajador:");
                Console.Write("Identificacion: ");
                string identificacion = Console.ReadLine();
                Console.Write("Nombre: ");
                string nombre = Console.ReadLine();
                Console.Write("Categoria del trabajador (1-Operador, 2-Técnico, 3-Profesional): ");
                int categoria = int.Parse(Console.ReadLine());
                Console.Write("Tarifa por hora: ");
                double tarifaHora = double.Parse(Console.ReadLine());
                Console.Write("Horas laboradas: ");
                int horasLaboradas = int.Parse(Console.ReadLine());

                // Crear un nuevo objeto Trabajador y agregarlo a la lista
                trabajadores.Add(new Trabajador(identificacion, nombre, categoria, tarifaHora, horasLaboradas));
                Console.WriteLine("¿Desea ingresar otro trabajador? (1-Si, 0-No): ");
                opcion = int.Parse(Console.ReadLine());
            } while (opcion != 0);

            // Mostrar resultados y estadísticas
            int operadoresCount = 0, tecnicosCount = 0, profesionalesCount = 0;
            double acumuladoOperadores = 0, acumuladoTecnicos = 0, acumuladoProfesionales = 0;

            foreach (var trabajador in trabajadores)
            {
                Console.WriteLine(trabajador);

                // Actualizar contadores y acumuladores según la categoría del trabajador
                switch (trabajador.Categoria)
                {
                    case 1:
                        operadoresCount++;
                        acumuladoOperadores += trabajador.SueldoNeto;
                        break;
                    case 2:
                        tecnicosCount++;
                        acumuladoTecnicos += trabajador.SueldoNeto;
                        break;
                    case 3:
                        profesionalesCount++;
                        acumuladoProfesionales += trabajador.SueldoNeto;
                        break;
                }
            }

            // Imprimir estadísticas
            Console.WriteLine("\nEstadísticas:");
            Console.WriteLine($"1) Cantidad de Trabajadores Tipo Operadores: {operadoresCount}");
            Console.WriteLine($"2) Acumulado Sueldo Neto para Operadores: {acumuladoOperadores}");
            Console.WriteLine($"3) Promedio Sueldo Neto para Operadores: {(operadoresCount > 0 ? acumuladoOperadores / operadoresCount : 0)}");
            Console.WriteLine($"4) Cantidad de Trabajadores Tipo Técnicos: {tecnicosCount}");
            Console.WriteLine($"5) Acumulado Sueldo Neto para Técnicos: {acumuladoTecnicos}");
            Console.WriteLine($"6) Promedio Sueldo Neto para Técnicos: {(tecnicosCount > 0 ? acumuladoTecnicos / tecnicosCount : 0)}");
            Console.WriteLine($"7) Cantidad de Trabajadores Tipo Profesionales: {profesionalesCount}");
            Console.WriteLine($"8) Acumulado Sueldo Neto para Profesionales: {acumuladoProfesionales}");
            Console.WriteLine($"9) Promedio Sueldo Neto para Profesionales: {(profesionalesCount > 0 ? acumuladoProfesionales / profesionalesCount : 0)}");
        }
    }
}