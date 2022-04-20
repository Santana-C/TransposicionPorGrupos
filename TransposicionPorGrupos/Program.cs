Console.WriteLine("Ingrese el mensaje:");
string mensajeOriginal = Console.ReadLine();
Console.WriteLine("Ingrese la permutación (separado por espacios):");
string permutacion = Console.ReadLine();

int[] arregloPermutacion = ObtenerArregloPermutacion(permutacion);
int mayor = Mayor(arregloPermutacion);

string[][] mensajePorGrupos = Agrupar(mensajeOriginal, mayor);
Console.Write("\nMensaje Por Grupos: ");
for(int i = 0; i < mensajePorGrupos.Length; i++) {
    for(int j = 0; j < mensajePorGrupos[i].Length; j++)
        Console.Write(mensajePorGrupos[i][j]);
    Console.Write(" ");
}

string[][] mensajePermutado = Permutar(mensajePorGrupos, arregloPermutacion);
Console.Write("\n\nMensaje Permutado: ");
for(int i = 0; i < mensajePermutado.Length; i++) {
    for(int j = 0; j < mensajePermutado[i].Length; j++)
        Console.Write(mensajePermutado[i][j]);
    Console.Write(" ");
}

string[][] mensajeRevertido = RevertirPermutacion(mensajePermutado, arregloPermutacion);
Console.Write("\n\nMensaje Revertido: ");
for(int i = 0; i < mensajeRevertido.Length; i++) {
    for(int j = 0; j < mensajeRevertido[i].Length; j++)
        Console.Write(mensajeRevertido[i][j]);
    Console.Write(" ");
}

#region Cifrar
string[][] Agrupar(string mensajeOriginal, int tamanioGrupo) {
    mensajeOriginal = mensajeOriginal.Replace(" ", String.Empty);

    Queue<string> cola = new Queue<string>();
    foreach(var item in mensajeOriginal) cola.Enqueue(item.ToString());
    int cantidadGrupos;
    if(mensajeOriginal.Length % tamanioGrupo == 0) cantidadGrupos = mensajeOriginal.Length / tamanioGrupo;
    else cantidadGrupos = (mensajeOriginal.Length / tamanioGrupo) + 1;

    string[][] grupos = new string[cantidadGrupos][];
    for(int i = 0; i < grupos.Length; i++) grupos[i] = new string[tamanioGrupo];
    for(int i = 0; i < cantidadGrupos; i++) {
        for(int j = 0; j < tamanioGrupo; j++) {
            if(cola.Count != 0) grupos[i][j] = cola.Dequeue();
            else grupos[i][j] = "X";
        }
    }
    return grupos;
}

string[][] Permutar(string[][] mensajePorGrupos, int[] arregloPermutacion) {
    string[][] arregloPermutado = new string[mensajePorGrupos.Length][];
    for(int i = 0; i < mensajePorGrupos.Length; i++) {
        arregloPermutado[i] = new string[mensajePorGrupos[i].Length];
        for(int j = 0; j < mensajePorGrupos[i].Length; j++)
            arregloPermutado[i][j] = mensajePorGrupos[i][arregloPermutacion[j] - 1];
    }
    return arregloPermutado;
}
#endregion

#region Descifrar
string[][] RevertirPermutacion(string[][] mensajePermutado, int[] arregloPermutacion) {
    string[][] mensajeRevertido = new string[mensajePermutado.Length][];
    for(int i = 0; i < mensajeRevertido.Length; i++) {
        mensajeRevertido[i] = new string[mensajePermutado[i].Length];
        for(int j = 0; j < mensajePermutado[i].Length; j++)
            mensajeRevertido[i][arregloPermutacion[j] - 1] = mensajePermutado[i][j];
    }
    return mensajeRevertido;
}
#endregion

#region Apoyo
int Mayor(int[] arreglo) {
    int mayor = 0;
    for(int i = 0; i < arreglo.Length; i++) {
        if(arreglo[i] > mayor) mayor = arreglo[i];
    }
    return mayor;
}

int[] ObtenerArregloPermutacion(string permutacion) {
    string[] arregloPermutacionS = permutacion.Split(" ");
    int[] arregloPermutacion = new int[arregloPermutacionS.Length];
    for(int i = 0; i < arregloPermutacionS.Length; i++)
        arregloPermutacion[i] = int.Parse(arregloPermutacionS[i]);
    return arregloPermutacion;
}
#endregion