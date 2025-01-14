import React, { createContext, useContext, useState } from 'react';
import { getTickets, getTicketById, createTicket, updateTicket, addReply } from '../api/ticketsApi';

const TicketsContext = createContext();

export const useTickets = () => {
    return useContext(TicketsContext);
};

const TicketsProvider = ({ children }) => {
    const [tickets, setTickets] = useState([]);
    const [loading, setLoading] = useState(false);

    const fetchTickets = async (paginationQuery) => {
        setLoading(true);
        try {
            const data = await getTickets(paginationQuery);
            setTickets(data.items);
        } catch (error) {
            console.error('Error fetching tickets:', error);
        } finally {
            setLoading(false);
        }
    };

    const fetchTicketById = async (id) => {
        try {
            return await getTicketById(id);
        } catch (error) {
            console.error('Error fetching ticket:', error);
            throw error;
        }
    };

    const saveTicket = async (ticket) => {
        try {
            if (ticket.id) {
                await updateTicket(ticket);
            } else {
                await createTicket(ticket);
            }
        } catch (error) {
            console.error('Error saving ticket:', error);
            throw error;
        }
    };

    const postReply = async (ticketId, reply) => {
        try {
            await addReply(ticketId, reply);
        } catch (error) {
            console.error('Error posting reply:', error);
            throw error;
        }
    };

    return (
        <TicketsContext.Provider
            value={{
                tickets,
                loading,
                fetchTickets,
                fetchTicketById,
                saveTicket,
                postReply,
            }}
        >
            {children}
        </TicketsContext.Provider>
    );
};

export default TicketsProvider;