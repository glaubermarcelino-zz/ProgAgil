import { Palestrante } from './Palestrante';
import { Evento } from './evento';

export interface RedeSocial{
    Id: number;
    Nome: string;
    URL: string;
    EventoId: number;
    Evento: Evento;
    PalestranteId: number;
    Palestrante: Palestrante;
}