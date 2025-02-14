import axios from 'axios';

const API_BASE_URL = 'https://localhost:7254/api/Ticket'; 


export const getTickets = async (paginationQuery) => {
    try {
        const response = await axios.post(
            `${API_BASE_URL}/GetAll`,
            paginationQuery,
            {
                headers: {
                    'Content-Type': 'application/json', 
                },
            }
        );
        return response.data;
    } catch (error) {
        console.error('Error fetching tickets:', error);
        throw error;
    }
};


export const getTicketById = async (id) => {
    try {
        const response = await axios.get(`${API_BASE_URL}/GetById`, {
            params: { id },
        });
        return response.data;
    } catch (error) {
        console.error('Error fetching ticket by ID:', error);
        throw error;
    }
};


export const createTicket = async (ticket) => {
    try {
        const response = await axios.post(`${API_BASE_URL}/Create`, ticket);
        return response.data;
    } catch (error) {
        console.error('Error creating ticket:', error);
        throw error;
    }
};


export const updateTicket = async (ticket) => {
    try {
        const response = await axios.put(`${API_BASE_URL}/Update`, ticket);
        return response.data;
    } catch (error) {
        console.error('Error updating ticket:', error);
        throw error;
    }
};


export const getTicketMetadata = async () => {
    try {
        const response = await axios.get(`${API_BASE_URL}/GetMetadata`);
        return response.data;
    } catch (error) {
        console.error('Error fetching ticket metadata:', error);
        throw error;
    }
};

export const addReply = async (ticketId, reply) => {
    const response = await axios.post(`/api/Ticket/AddReply`, {
        ticketId,
        text: reply,
    });
    return response.data;
};