import React from 'react';

const TicketHeader = ({ ticketNumber, ticketTitle, onClose, onSave }) => {
    return (
        <div className="d-flex justify-content-between align-items-center mb-4">
            <div>
                <strong>Ticket #</strong>{" "}
                {ticketNumber ? ticketNumber : "New"}
                {ticketTitle && ` - ${ticketTitle}`}
            </div>
            <div>
                <button className="btn btn-secondary me-2" onClick={onClose}>
                    Close
                </button>
                <button className="btn btn-success" onClick={onSave}>
                    Save
                </button>
            </div>
        </div>
    );
};

export default TicketHeader;