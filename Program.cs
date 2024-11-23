using System.Text.RegularExpressions;
using EspacioTareas;
using funciones;
List<Tarea> TareasPendientes = new List<Tarea>();
List<Tarea> TareasRealizadas = new List<Tarea>();
//numero random para determinar las tareas pendientes//
Random generadorRandom = new Random();
int totalTareas = generadorRandom.Next(1,11);
//bucle for para cargar el estado de la tarea//
for(int i = 0; i < totalTareas; i++){
    Console.WriteLine("ingrese la descripcion de la tarea:");
    string descripcion = Console.ReadLine();
    //random para la duracion de la tarea entre 10-100//
    int duracionTarea = generadorRandom.Next(10,101);
    //usamos la variable i para el id de cada tarea//
    TareasPendientes.Add(new Tarea(i+1,descripcion,duracionTarea));
}

//mostramos las tareas con un bucle forEach//
foreach(Tarea tarea in TareasPendientes){
    tarea.MostrarTarea();
}


//variable para controlar el bucle//
bool bucle = true;
while(bucle){
    Console.WriteLine("1: Mover Tareas Pendientes A Realizadas");
    Console.WriteLine("2: Buscar Tareas Pendientes Por Descripcion");
    Console.WriteLine("3: Mostrar Lista De Pendientes");
    Console.WriteLine("4: Mostrar Lista De Realizadas");
    Console.WriteLine("5: Salir");
    Console.WriteLine("eliga una opcion:");
    string eleccionCadena = Console.ReadLine();
    int eleccion = default;
    bool resultadoConversion = int.TryParse(eleccionCadena, out eleccion);
    if(resultadoConversion && eleccion >= 1 && eleccion <= 4){
        switch(eleccion){
            case 1: 
                //mostramos las tareas pendientes//
                FuncionesLista.MostrarLista(TareasPendientes,"TAREAS PENDIENTES");
                //pedimos al usuario que ingrese el id de la tarea que quiere mover a tarea realizadas//
                Console.WriteLine("Ingrese el id de la tarea que desea mover:");
                string indiceTareaCadena = Console.ReadLine();
                int indiceTarea = default;
                bool resultadoConversionIndice = int.TryParse(indiceTareaCadena, out indiceTarea);
                //variable para guardar la tarea en caso de encontrarla//
                Tarea tareaAMover = null;
                if(resultadoConversionIndice){
                    //buscamos si alguna tarea coincide con el indice//
                    foreach(Tarea tarea in TareasPendientes){
                        if(tarea.TareaID == indiceTarea){
                            tareaAMover = tarea;
                            break;
                        }
                    }
                    //si tareaAMover es distinto de null eliminamos la tarea de tareasPendientes y la agregamos a tareasRealizadas//
                    if(tareaAMover != null){
                        TareasPendientes.Remove(tareaAMover);
                        TareasRealizadas.Add(tareaAMover);
                    }else{
                        Console.WriteLine("no se indico una tarea existente");
                    }
                }else{
                    Console.WriteLine("Por favor ingrese un numero");
                }

            break;

            case 2:
                //le pedimos al usuario que ingrese una descripcion//
                Console.WriteLine("ingrese la descripcion:");
                string descripcion = Console.ReadLine();
                //variable para controlar en caso que no haya ninguna tarea con esa descripcion//
                bool seEncontroTarea = false;
                //usamos un bucle forEach para ver si hay descripciones que coincidan//
                foreach(Tarea tarea in TareasPendientes){
                    if(tarea.Descripcion.Contains(descripcion)){
                        tarea.MostrarTarea();
                    }
                }

                if(!seEncontroTarea){
                    Console.WriteLine("No Existen Tareas Que Coincidan Con Esa Descripcion");
                }
            
            break;

            case 3:
                FuncionesLista.MostrarLista(TareasPendientes,"TAREAS PENDIENTES");
            break;

            case 4:
                FuncionesLista.MostrarLista(TareasRealizadas,"TAREAS REALIZADAS");
            break;
                
        }
    }else if(eleccion == 5){
        Console.WriteLine("Saliendo...");
        bucle = false;
    }else{
        Console.WriteLine("no se indico una opcion valida");
    }
}