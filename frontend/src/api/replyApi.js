import axios from 'axios';

const API_BASE_URL = 'https://localhost:7254/api/Reply';

export const getRepliesByTicketId = async (ticketId) => {
    try {
        const response = await axios.get(`${API_BASE_URL}/GetByTicketId`, {
            params: { ticketId },
        });
        return response.data;
    } catch (error) {
        console.error('Error fetching replies by ticket ID:', error);
        throw error;
    }
};

export const getAllReplies = async () => {
    try {
        const response = await axios.get(`${API_BASE_URL}/GetAll`);
        return response.data;
    } catch (error) {
        console.error('Error fetching all replies:', error);
        throw error;
    }
};

export const createReply = async (reply) => {
    try {
        const response = await axios.post(`${API_BASE_URL}/Create`, reply, {
            headers: {
                'Content-Type': 'application/json',
            },
        });
        return response.data;
    } catch (error) {
        console.error('Error creating reply:', error);
        throw error;
    }
};

export const updateReply = async (reply) => {
    try {
        const response = await axios.put(`${API_BASE_URL}/Update`, reply, {
            headers: {
                'Content-Type': 'application/json',
            },
        });
        return response.data;
    } catch (error) {
        console.error('Error updating reply:', error);
        throw error;
    }
};