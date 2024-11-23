namespace EspacioTareas;

class Tarea{
    //definimos los campos//
    private int tareaID;
    private string descripcion;
    private int duracion;

    
    //definimos las propiedades//
    public int TareaID { get => tareaID; set => tareaID = value; }
    public string Descripcion { get => descripcion; set => descripcion = value; }
    public int Duracion { get => duracion; set => duracion = value; }

    //definimos el constructor//
    public Tarea(int tareaID, string descripcion, int duracion)
    {
        TareaID = tareaID;
        Descripcion = descripcion;
        Duracion = duracion;
    }

    //metodo para mostrar el estado de la tarea//
    public void MostrarTarea(){
        Console.WriteLine("----------TAREA----------");
        Console.WriteLine("Descripcion: "+Descripcion);
        Console.WriteLine("Duracion: "+Duracion);
        Console.WriteLine("ID: "+TareaID);
    }


}