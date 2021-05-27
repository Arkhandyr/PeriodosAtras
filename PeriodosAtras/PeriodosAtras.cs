using System;
using System.Collections.Generic;

namespace Periodos_Atras.ClassLibrary
{
    public class PeriodosAtras
    {
        String[] unidades = new String[] { "", "um", "dois", "três", "quatro", "cinco", "seis", "sete", "oito", "nove" };
        String[] dezVinte = new String[] { "", "onze", "doze", "treze", "quatorze", "quinze", "dezesseis", "dezessete", "dezoito", "dezenove" };
        String[] dezenas = new String[] { "", "dez", "vinte", "trinta", "quarenta", "cinquenta", "sessenta", "setenta", "oitenta", "noventa" };

        String[] unidadesTempoSingular = new String[] { "segundo", "minuto", "hora", "dia", "semana", "mês", "ano" };
        String[] unidadesTempoPlural = new String[] { "segundos", "minutos", "horas", "dias", "semanas", "meses", "anos" };
        public string periodoPorExtenso(DateTime data)
        {
            if (data > DateTime.Now)
                return "Data futura!";

            List<String> listaDeUnidades = listaUnidades(data);

            Queue<String> periodoPorExtenso = new Queue<String>();

            int iUnidadesTempo = listaDeUnidades.Count - 1;
            for (int i = 0; i < listaDeUnidades.Count; i++)
            {
                String separador = "";
                String unidadeTempo = "";

                String unidadeAtual = listaDeUnidades[i];
                unidadeTempo += getUnidadeTempo(iUnidadesTempo, unidadeAtual);

                periodoPorExtenso.Enqueue(unidadeEmExtenso(unidadeAtual, iUnidadesTempo));

                if (unidadeAtual != "00")
                {
                    if (iUnidadesTempo == listaDeUnidades.Count - 2 && listaDeUnidades[i+1] != "00") separador = " e ";
                    else separador = " ";
                    periodoPorExtenso.Enqueue(" " + unidadeTempo + separador);
                }
                iUnidadesTempo--;
            }
            periodoPorExtenso.Enqueue("atrás");
            return montarString(periodoPorExtenso);
        }
        private string getUnidadeTempo(int iUnidadesTempo, String unidade)
        {
            if (unidade == "01") return unidadesTempoSingular[iUnidadesTempo];
            else return unidadesTempoPlural[iUnidadesTempo];
        }
        private string montarString(Queue<String> unidadePorExtenso)
        {
            String chequePorExtenso = null;
            while (unidadePorExtenso.Count > 0)
                chequePorExtenso += unidadePorExtenso.Dequeue();
            return chequePorExtenso;
        }
        private string unidadeEmExtenso(String unidadeTempo, int iUnidadesTempo)
        {
            String separacao = "";

            int dezena = (int)Char.GetNumericValue(unidadeTempo[0]);
            int unidade = (int)Char.GetNumericValue(unidadeTempo[1]);

            String dezenas = this.dezenas[dezena];
            String unidades = this.unidades[unidade];

            if (dezena == 1 && unidade != 0) { dezenas = dezVinte[unidade]; unidades = ""; }
            else if (dezena > 1 && unidade != 0) separacao = " e ";

            if (unidadeTempo == "01" && (iUnidadesTempo == 2 || iUnidadesTempo == 4)) unidades = "uma";
            else if (unidadeTempo == "02" && (iUnidadesTempo == 2 || iUnidadesTempo == 4)) unidades = "duas";

            return dezenas + separacao + unidades;
        }
        private List<String> listaUnidades(DateTime data)
        {
            DateTime agora = DateTime.Now;
            TimeSpan periodo = agora - data;
            List<Double> listaUnidades = new List<Double>();

            int resto = periodo.Days % 365;
            listaUnidades.Add(periodo.Days / 365);
            listaUnidades.Add(resto / 30);
            resto = resto % 30;
            listaUnidades.Add(resto / 7);
            resto = resto % 7;
            listaUnidades.Add(resto);
            listaUnidades.Add(resto / 24);
            resto = resto % 24;
            listaUnidades.Add(resto / 60);
            resto = resto % 60;
            listaUnidades.Add(resto / 60);

            List<String> listaUnidadesString = new List<String>();
            foreach (Double unidade in listaUnidades)
            {
                String unidadeStr = unidade.ToString();
                if (unidadeStr.Length < 2) unidadeStr = "0" + unidadeStr;
                listaUnidadesString.Add(unidadeStr);
            }
            return listaUnidadesString;
        }
    }
}