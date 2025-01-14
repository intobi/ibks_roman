import React from 'react';
import { useNavigate } from 'react-router-dom';

const AddTicketButton = () => {
    const navigate = useNavigate();

    return (
        <div className="d-flex justify-content-end mb-3">
            <button
                className="btn btn-success"
                onClick={() => navigate('/tickets/new')}
            >
                Add New Ticket
            </button>
        </div>
    );
};

export default AddTicketButton;