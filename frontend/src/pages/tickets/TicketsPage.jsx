import React, { useState, useEffect } from 'react';
import TicketsTable from '../../components/Tickets/TicketsTable';
import Pagination from '../../components/Pagination/Pagination';
import AddTicketButton from '../../components/Buttons/AddTicketButton';
import { getTickets } from '../../api/ticketsApi';
import PaginationQuery from '../../api/models/PaginationQuery.ts';

const TicketsPage = () => {

    const [tickets, setTickets] = useState([]);
    const [loading, setLoading] = useState(true);

    const [currentPage, setCurrentPage] = useState(1);
    const [totalPages, setTotalPages] = useState(0);
    const [pageSize, setPageSize] = useState(10);

    useEffect(() => {
        const fetchTickets = async () => {
            setLoading(true);
            try {
                const paginationQuery = new PaginationQuery(currentPage, pageSize);
                const response = await getTickets(paginationQuery);
                setTickets(response.items);
                setTotalPages(Math.ceil(response.totalCount / pageSize));
            } catch (error) {
                console.error('Error fetching tickets:', error);
            } finally {
                setLoading(false);
            }
        };

        fetchTickets();
    }, [currentPage, pageSize]);

    return (
        <div className="container mt-4">
            <h1 className="mb-4">Tickets</h1>

            <AddTicketButton />

            {loading ? (
                <p>Loading tickets...</p>
            ) : (
                <TicketsTable tickets={tickets} />
            )}

            <Pagination
                currentPage={currentPage}
                totalPages={totalPages}
                onPageChange={setCurrentPage}
                onPageSizeChange={setPageSize}
                pageSize={pageSize}
            />
        </div>
    );
};

export default TicketsPage;