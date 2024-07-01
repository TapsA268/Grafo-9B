class Circulo
{
    constructor(xc, yc, radio, color) 
    {
        this.posiX = xc;
        this.posiY = yc;
        this.radio = radio;
        this.color = color;
    }

    draw(contexto) 
    {
        contexto.beginPath();        
        contexto.arc(this.posiX, this.posiY, this.radio, 0, 2 * Math.PI);
        contexto.fillStyle = this.color;
        contexto.fill();
        contexto.closePath();
    }
}