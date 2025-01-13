import React from 'react';

const TicketsTable = ({ tickets }) => {
    return (
        <table className="table table-bordered table-striped">
            <thead className="thead-dark">
                <tr>
                    <th>Lvl</th>
                    <th>#</th>
                    <th>Title</th>
                    <th>Module</th>
                    <th>Type</th>
                    <th>State</th>
                    <th>Actions</th>
                </tr>
            </thead>
            <tbody>
                {tickets.length > 0 ? (
                    tickets.map((ticket) => (
                        <tr key={ticket.id}>
                            <td>
                                <div
                                    style={{
                                        width: '20px',
                                        height: '20px',
                                        backgroundColor: getPriorityColor(ticket.lvl),
                                        borderRadius: '50%',
                                    }}
                                ></div>
                            </td>
                            <td>{ticket.id}</td>
                            <td>{ticket.title}</td>
                            <td>{ticket.module}</td>
                            <td>{ticket.type}</td>
                            <td>{ticket.state}</td>
                            <td>
                                <button className="btn btn-primary btn-sm">Edit</button>
                            </td>
                        </tr>
                    ))
                ) : (
                    <tr>
                        <td colSpan="7" className="text-center">
                            No tickets found
                        </td>
                    </tr>
                )}
            </tbody>
        </table>
    );
};

// Функція для отримання кольору пріоритету
const getPriorityColor = (priority) => {
    switch (priority) {
        case 'High':
            return 'red';
        case 'Medium':
            return 'yellow';
        case 'Low':
            return 'green';
        default:
            return 'gray';
    }
};

export default TicketsTable;