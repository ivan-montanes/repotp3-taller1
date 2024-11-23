namespace funciones;
using EspacioTareas;
//funcion para mostrar la lista y verificar que no este vacia//
static class FuncionesLista{
    public static void MostrarLista(List<Tarea> lista,string nombreLista){
        if(lista.Count != 0){
            Console.WriteLine($"----------{nombreLista}------------");
            foreach(Tarea tarea in lista){
                tarea.MostrarTarea();
            }
        }else{
            Console.WriteLine("---------LA LISTA ESTA VACIA-----------");
        }
    }
}