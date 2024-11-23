namespace EspacioCalculadora;

public enum TipoOperacion{
    Suma,
    Resta,
    Multiplicacion,
    Division,
    Limpiar
}

public class Operacion{
    private double resultadoAnterior;
    private double nuevoValor;
    private TipoOperacion operacion;

    public Operacion(double resultadoAnterior, double resultado, TipoOperacion operacionn)
    {
        ResultadoAnterior = resultadoAnterior;
        Resultado = resultado;
        Operacionn = operacionn;
    }

    public double ResultadoAnterior { get => resultadoAnterior; set => resultadoAnterior = value; }
    public double Resultado { get => nuevoValor; set => nuevoValor = value; }
    public TipoOperacion Operacionn { get => operacion; set => operacion = value; }

}

class Calculadora{
    
    //definimos lo/los campos//
    private double dato;
    private List<Operacion> historial;

    //definimos la/las propiedades para acceder a los campos//
    public double Resultado 
    {
        get => dato;
    }
    public List<Operacion> Historial { get => historial; }

    //definimos los metodos//
    private void Sumar (double valor){
        double resultadoAnterior = dato;
        dato += valor;
        historial.Add(new Operacion(resultadoAnterior,dato,TipoOperacion.Suma));
    }

    private void Restar (double valor){
        double resultadoAnterior = dato;
        dato -= valor;
        historial.Add(new Operacion(resultadoAnterior,dato,TipoOperacion.Resta));
    }

    private void Multiplciar (double valor){
        double resultadoAnterior = dato;
        dato *= valor;
        historial.Add(new Operacion(resultadoAnterior,dato,TipoOperacion.Multiplicacion));
    }

    private void Dividir (double valor){
        if(valor != 0){
            double resultadoAnterior = dato;
            dato /= valor;
            historial.Add(new Operacion(resultadoAnterior,dato,TipoOperacion.Division));
        }else{
            Console.WriteLine("no se puede dividir por 0");
        }
    }

    private void Limpiar(){
        double resultadoAnterior = dato;
        dato = 0;
        historial.Add(new Operacion(resultadoAnterior,dato,TipoOperacion.Limpiar));
    }

    private void MostrarHistorial(){
        //controlamos que la lista no este vacio//
        if(historial.Count != 0){
            int i = 1;
            foreach(Operacion operacion in historial){
                Console.WriteLine($"----------OPERACION {i}----------");
                Console.WriteLine($"Resultado Anterior {operacion.ResultadoAnterior}");
                Console.WriteLine($"Nuevo Resultado: {operacion.Resultado}");
                Console.WriteLine($"Tipo De Operacion: {operacion.Operacionn}");
                i++;
            }
        }else{
            Console.WriteLine("---------NO SE REALIZARON OPERACIONES HASTA AHORA------------");
        }
        //variable para enumerar las operaciones//
        
    }

    //metodo para encadenar operaciones//
    public void EncadenarOperaciones(){
        //inicializamos la lista//
        historial = new List<Operacion>();
        //variable para controlar el bucle//
        bool bucle = true;
        while(bucle){
            Console.WriteLine("----------CALCULADORA----------");
            Console.WriteLine($"Valor Actual: {this.Resultado}");
            Console.WriteLine("1: Sumar");
            Console.WriteLine("2: Restar");
            Console.WriteLine("3: Multiplicar");
            Console.WriteLine("4: Dividir");
            Console.WriteLine("5: Limpiar");
            Console.WriteLine("6: Mostrar Historial");
            Console.WriteLine("7: Salir");
            Console.WriteLine("eliga una operacion:");
            string elegirOperacionCadena = Console.ReadLine();
            int operacion = 0;
            bool resultadoConversion = int.TryParse(elegirOperacionCadena, out operacion);
            if(resultadoConversion && operacion >= 1 && operacion <= 4){
                //pedimos el numero al usuario//
                Console.WriteLine("ingrese un numero");
                string numeroCadena = Console.ReadLine();
                double numero = 0; 
                bool resultadoConversionNumero = double.TryParse(numeroCadena, out numero);
                if(resultadoConversionNumero){
                    //decidimos que operacion aplicar utilizando la estructura de control de flujo switch//
                    switch(operacion){
                        case 1:
                            this.Sumar(numero);
                        break;

                        case 2:
                            this.Restar(numero);
                        break;

                        case 3:
                            this.Multiplciar(numero);
                        break;

                        case 4:
                            this.Dividir(numero);
                        break;
                    }
                }else{
                    Console.WriteLine("No se ingreso un numero");
                }
            }else if(resultadoConversion && operacion == 5){
                this.Limpiar();
            }else if(operacion == 6){
                MostrarHistorial();
            }else if(operacion == 7){
                Console.WriteLine("Saliendo...");
                bucle = false;
            }else{
                Console.WriteLine("No se indico una opcion valida");
            }
        }
    }

   
}