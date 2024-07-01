class Circulo
{
    constructor(xc, yc, radio, color) 
    {
        this.posiX = xc;
        this.posiY = yc;
        this.radio = radio;
        this.color = color;
    }

    draw(contexto2) 
    {
        contexto2.beginPath();
        contexto2.strokeStyle=this.color;
        contexto2.arc(this.posiX, this.posiY, this.radio, 0, 2 * Math.PI);
        contexto2.stroke();
        contexto2.closePath();
    }
}