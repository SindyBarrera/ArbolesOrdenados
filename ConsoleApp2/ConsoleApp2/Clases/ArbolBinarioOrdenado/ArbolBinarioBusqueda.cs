using System;
/**
*
* @author Sindy
*/
public class ArbolBinarioBusqueda : ArbolBinario { //HEREDANDO ARBOLBINARIO

    public ArbolBinarioBusqueda() : base() {
       
    }

    
    public Nodo buscar(object buscado) {
        //IMPORTANDO NODO
        Comparador dato; 
        dato = (Comparador) buscado;
        if (raiz == null) {
            return null;
        } else {
            return localizar(raizArbol(), dato); //RETORNANDO LA RAIZ DEL ARBOL
        }
    }


    
    //PARTE DE LOCALIZAR
    //COMO PARAMETRO NODO 
    //COMPARADOR PARA HACER LA ITERACION
    //LOCALIZAR LO QUE HACE ES A QUE NODO Y DE QUE LADO SE VA A IR
    protected Nodo localizar(Nodo raizSub, Comparador buscado) { //CREADO COMO UN TIPO DE ACCESIVIDAD PROTEGIDO
        if (raizSub == null) { //SI LA RAIZ ES NULA
            return null;
        } else if (buscado.igualQue(raizSub.valorNodo())) { //BUSQUEDA RECURSIVA PROPIA ENTRE TODO EL ARBOL
            return raiz; //SI ES IGUAL NOS VA A RETORNAR LA RAIZ
        } else if (buscado.menorQue(raizSub.valorNodo())) {
            return localizar(raizSub.subarbolIzquierdo(), buscado); //ME VA A DEVOLVER ES LOCALIZAR EL NODO DE DONDE SE ENCUETRA Y YA SABEMOS SI LO VAMOS A DIRECCIONAR A LA  IZQUIERA
        } else {
            return localizar(raizSub.subarbolDerecho(), buscado); //SI NO ENVIARLE EL DERECHO
        }
    }

    public Nodo buscarIterativo(object buscado) {
        Comparador dato;
        bool encontrado = false;
        Nodo raizSub = raiz;
        dato = (Comparador) buscado;
        while (!encontrado && raizSub != null) {
            if (dato.igualQue(raizSub.valorNodo())) {
                encontrado = true;
            } else if (dato.menorQue(raizSub.valorNodo())) {
                raizSub = raizSub.subarbolIzquierdo();
            } else {
                raizSub = raizSub.subarbolDerecho();
            }
        }
        return raizSub;
        //return dato;
    }


    //PARTE PARA LA INSERCION
    //porque insertar se repite en esta misma clase?
    //Vamos a insertar un nuevo nodo entonces le pasamos el valor
    //El nodo va a tener el numero de carnet 
    public void insertar(object valor)  {
        Comparador dato;
        dato = (Comparador) valor; //Casteo de comparador
        raiz = insertar(raiz, dato);//Le mandamos la raiz y le mandamos el nodo porque lo estamos ubicando
    }


    //método interno para realizar la operación
    protected Nodo insertar(Nodo raizSub, Comparador dato)  { //COMO PARAMETROS RAIZ Y COMPARADOR
        if (raizSub == null) {
            raizSub = new Nodo(dato); //Si es nulo no hay nada que comparar

            //Si el dato es menor le decimos que lo inserte a la izquierda
        } else if (dato.menorQue(raizSub.valorNodo())) { //SI ES MENOR QUE 
            Nodo iz; //Variable para nodo izquierdo
            iz = insertar(raizSub.subarbolIzquierdo(), dato); //Insertando hacia la rama izquierda
            raizSub.ramaIzdo(iz); //Tirandolo para la rama izquierda

            //Si el dato es menor le decimos que lo inserte a la derecha
        }
        else if (dato.mayorQue(raizSub.valorNodo())) {//SI ES MAYOR QUE
            Nodo dr; //Variable para nodo derecho
            dr = insertar(raizSub.subarbolDerecho(), dato); //Insertando hacia la rama derecha
            raizSub.ramaDcho(dr); //Tirandolo para la rama derecha

        } else {
            // throw new Exception("Nodo duplicado");
            Console.WriteLine($"duplicado!!!! {raizSub.valorNodo()}");
        }
        return raizSub; //Retornando la raiz del subarbol
    }


    //PARA ELIMINAR
    public void eliminar(object valor)  { //Recibiendo el object que es el valor que vamos a eliminar
        Comparador dato;
        dato = (Comparador) valor;
        raiz = eliminar(raiz, dato);
    }
//método interno para realizar la operación

    protected Nodo eliminar(Nodo raizSub, Comparador dato)  { //Enviamos como parametro raizSub y dato
        if (raizSub == null) {  
            throw new Exception("No encontrado el nodo con la clave"); //Si es nulo no hay nada que eliminar y lanzamos una excepcion
        
            //Si el dato es menor que 
        } else if (dato.menorQue(raizSub.valorNodo())) {
            Nodo iz;
            iz = eliminar(raizSub.subarbolIzquierdo(), dato);  //Eliminamos la rama izquierda
            raizSub.ramaIzdo(iz);

            //Si el dato es mayor que
        } else if (dato.mayorQue(raizSub.valorNodo())) {
            Nodo dr;
            dr = eliminar(raizSub.subarbolDerecho(), dato); //Eliminamos la rama derecha
            raizSub.ramaDcho(dr);


        } else // Nodo encontrado
        {
            Nodo q; 
            q = raizSub; // nodo a quitar del árbol
            if (q.subarbolIzquierdo() == null) { //Si no tiene valor en la izquierda
                raizSub = q.subarbolDerecho(); //Agarramos la derecha

            } else if (q.subarbolDerecho() == null) { //Si no tiene valor en la derecha
                raizSub = q.subarbolIzquierdo();  //Agarramos el izquierda

                //Si ninguno es nulo 
            } else { // tiene rama izquierda y derecha
                q = reemplazar(q); //Lo reemplazamos
            }
            q = null; //De lo contrario q es igual a nulo
        }
        return raizSub; 
    }


// Método interno para susutituir por el mayor de los menores

    private Nodo reemplazar(Nodo act) { //Nodo act que es el que se va a reemplazar 
        Nodo a, p;  
        p = act; //P va a ser el nodo actual
        a = act.subarbolIzquierdo(); //Porque es la rama de nodos menores

        while (a.subarbolDerecho() != null) {//Mientras la rama del nodo derecho sea diferente a nulo
           //Hacemos el recorrido recursivo
            p = a; //
            a = a.subarbolDerecho(); //Hasta que encontremos el que es nulo
        }
        
        act.nuevoValor(a.valorNodo()); //Le ponemos el nuevo valor que es el valor nodo que estamos utilizando

        //Comparando para ver hacia donde lo tiramos
        if (p == act) { //Si p es igual al valor actual 
            p.ramaIzdo(a.subarbolIzquierdo()); 

        } else {
            p.ramaDcho(a.subarbolIzquierdo());
        }
        return a; 
    }

}
