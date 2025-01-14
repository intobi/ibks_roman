import { useContext } from 'react';
import { TicketsContext } from '../context/TicketsContext';

export const useTickets = () => {
    return useContext(TicketsContext);
};