import React from 'react';
import { useNavigate } from 'react-router-dom';

const AddTicketButton = () => {
    const navigate = useNavigate();

    return (
        <button
            className="btn btn-success mb-3"
            onClick={() => navigate('/tickets/new')}
        >
            Add New Ticket
        </button>
    );
};

export default AddTicketButton;