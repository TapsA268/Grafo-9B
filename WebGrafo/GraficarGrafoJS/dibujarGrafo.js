function dibujarGrafo(jsonGrafo)
{
    let grafo = jsonGrafo;

    try
    {
        grafo = JSON.parse(jsonGrafo);
    }
    catch (error)
    {
        console.error("Error de conversión de JSON:", error);
        return;
    }

    // Configuración del Canvas
    let grados = 0;
    const inc_grados = 360 / grafo.ListaAdyacencia.length; // Distribuir vértices uniformemente
    const hip = 450;
    const rad = 50;

    // Contexto gráfico
    const canvas = document.getElementById("Canvas1");
    const context = canvas.getContext('2d');

    // Limpiar el canvas antes de dibujar
    context.clearRect(0, 0, canvas.width, canvas.height);

    // Obtener las dimensiones del área de dibujo
    const tx = canvas.width;
    const ty = canvas.height;

    // Variables para el centro
    const xc = tx / 2;
    const yc = ty / 2;

    const posicionesVertices = [];

    // Dibujar los vértices
    grafo.ListaAdyacencia.forEach((vertice, index) => {
        const trigo2 = new trigonometria((2 * Math.PI * grados) / 360, hip);
        const xxc = xc + trigo2.ObtenerAdyacente();
        const yyc = yc - trigo2.ObtenerOpuesto();
        var datos = `Nombre: ${vertice.entidadInfo.Nombre} Edad: ${vertice.entidadInfo.Edad}`

        const circ = new Circulo(xxc, yyc, rad, '#04BF8A');
        circ.draw(context);

        // Guardar posición del vértice
        posicionesVertices.push({ x: xxc, y: yyc });

        // Dibujar el texto dentro del círculo
        context.textAlign = "center";
        context.textBaseline = "middle";
        context.font = "12px Arial";
        context.fillStyle = 'white';
        context.fillText(datos, xxc, yyc);

        grados += inc_grados; // Incrementar grados
    });

    // Función para dibujar flecha
    function dibujarFlecha(context, origenX, origenY, destinoX, destinoY)
    {
        const punta = 10;
        const dx = destinoX - origenX;
        const dy = destinoY - origenY;
        const angulo = Math.atan2(dy, dx);
        context.moveTo(origenX, origenY);
        context.lineTo(destinoX, destinoY);
        context.lineTo(destinoX - punta * Math.cos(angulo - Math.PI / 6), destinoY - punta * Math.sin(angulo - Math.PI / 6));
        context.moveTo(destinoX, destinoY);
        context.lineTo(destinoX - punta * Math.cos(angulo + Math.PI / 6), destinoY - punta * Math.sin(angulo + Math.PI / 6));
    }

    // Dibujar las aristas
    grafo.ListaAdyacencia.forEach((vertice, indice) => {
        let actual = vertice.listaEnlaces.inicio;
        while (actual) {
            const destino = actual.numVertices;

            // Calculamos los puntos en el perímetro del círculo
            const inicio = posicionesVertices[indice];
            const fin = posicionesVertices[destino];

            const angulo = Math.atan2(fin.y - inicio.y, fin.x - inicio.x);

            const inicioX = inicio.x + rad * Math.cos(angulo);
            const inicioY = inicio.y + rad * Math.sin(angulo);
            const finX = fin.x - rad * Math.cos(angulo);
            const finY = fin.y - rad * Math.sin(angulo);

            context.lineWidth = 3;
            context.strokeStyle = '#026873';
            context.beginPath();
            dibujarFlecha(context, inicioX, inicioY, finX, finY);
            context.closePath();
            context.stroke();

            const medX = (inicioX + finX) / 2;
            const medY = (inicioY + finY) / 2;
            const des = 10; 

            context.fillStyle = 'white';
            context.font = '12px Arial';
            context.fillText(actual.costo, medX, medY + des);

            actual = actual.next;
        }
    });
}