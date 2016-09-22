using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace AuxiliarKinect.FuncoesBasicas
{
    public class Sessao
    {
        public Queue<String> movimentos { get; set; }
        public Queue<int> repeticoes { get; set; }
        public Queue<int> serie { get; set; }

        private TimerPlus timer;
        private int contadorRepeticao;
        private int contadorSerie;

        public Sessao()
        {
            movimentos = new Queue<string>();
            repeticoes = new Queue<int>();
            serie = new Queue<int>();
            contadorRepeticao = 0;
            contadorSerie = 0;
            setTimer();
        }

        public void ProximaRepeticao()
        {
            contadorRepeticao++;
            Console.WriteLine("Repeticao locona " + contadorRepeticao);
        }
        public void ProximaSerie()
        {
            contadorSerie++;
            Console.WriteLine("Sessao locona " + contadorSerie);
        }

        public int RepeticaoAtual()
        {
            return contadorRepeticao;
        }
    
        public int SerieAtual()
        {
            return contadorSerie;
        }

        public String proximoMovimento()
        {

            if (timer != null && timer.Enabled)
            {
                return "intervalo";
            }

            if(repeticoes.Count == 0 || serie.Count == 0 || movimentos.Count == 0)
            {
                return "fim";
            }

            if (repeticoes.Peek() == contadorRepeticao)
            {
                contadorRepeticao = 0;
                ProximaSerie();
                startTimer();
                return "intervalo";
            }

            else if(contadorSerie == serie.Peek() && IntervaloFinalizado())
            {
                Console.WriteLine("Proximo mov");
                movimentos.Dequeue();
                repeticoes.Dequeue();
                serie.Dequeue();
                contadorRepeticao = 0;
                contadorSerie = 0;
                return "proximo";
            }


           

            else if (movimentos.Peek().Equals("pausa"))
            {
                return movimentos.Dequeue();
            }

            return movimentos.Peek();
        }

        public void start(Queue<string> mov, Queue<int> rep, Queue<int> ser)
        {
            movimentos = mov;
            repeticoes = rep;
            serie = ser;
        }

        public void setTimer()
        {

            timer = new TimerPlus();
            timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            timer.Interval = 5000;
            timer.AutoReset = false;
        }

        public void startTimer()
        {
            timer.Start();
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            timer.Stop();
        }

        public int timeLeft()
        {
            return  (int) (timer.TimeLeft / 1000);
        }

        public bool IntervaloFinalizado()
        {
            return timer.Enabled ? false : true; 
        }
    }
}
