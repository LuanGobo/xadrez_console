using System;
using tabuleiro;

namespace xadrez
{
    internal class PartidaDeXadrez
    {
        public Tabuleiro tab { get; private set; }
        private int turno;
        private Cor jogadorAtual;
        public bool terminada { get; private set; }

        public PartidaDeXadrez()
        {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            terminada = false;
            colocarPecas();
        }

        public void executaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = tab.retirarPeca(origem);
            p.incrementarQteMoviemntos();
            Peca pecaCapturada = tab.retirarPeca(destino);
            tab.colocarpeca(p, destino);
        }

        private void colocarPecas()
        {
            tab.colocarpeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('c',1).toPosicao());
        }
    }
}
