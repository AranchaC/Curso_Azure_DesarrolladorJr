//Systgem es el namespace original de .NET.
using System.Numerics;
using novedades_net8;


main();


//*** Cadenas literales en crudo. ***
//void main()
//{
//    string nombre = "Juan";
//    //string texto = "Hola, ¿qué tal?," +
//    //    $"Tú nombre es {nombre}";

//    string saludo = 
//        $"""
//            Hola, ¿qué tal?, tú nombre es {nombre}.
//            Esta es una forma para escribir texto continuo en C#
//        """;
//    Console.WriteLine(saludo);
//}


//*** Verificar parámetros nulos con el operador !!. ***
//void Saludar(string nombre!!)
//{
//    Console.WriteLine($"Hola {nombre}");
//}
//void main()
//{
//    Saludar("Ana");
//}


//*** Matemáticas genéricas con Interfaces estáticas abstractas. ***
//T Sumar<T>(T a, T b) where T : INumber<T>
//{
//    return a + b;
//}
//void main()
//{
//    int sumInt = Sumar(2, 6);
//    double sumDouble = Sumar(2.5, 6.9);
//    Console.WriteLine(
//        $"""
//        Resultado de la suma de enteros es {sumInt} 
//        y el resultado de la suma de decimales es {sumDouble}.
//        (Ejemplo pasando 2 números de tipos diferentes).
//        """);
//}


//*** Crear entidad como registro con "record". ***
void main()
{
    InventarioClass inventarioClass = new InventarioClass();
    var inventarioObtenido = inventarioClass.ListaDeInventario();
    foreach (var inv in inventarioObtenido)
    {
        Console.WriteLine(
            $"""
                Identificador: {inv.id}.
                Nombre: {inv.Nombre}.
                Precio: {inv.Precio}.
                Stock: {inv.Stock}.

             """
         );
    }
}



