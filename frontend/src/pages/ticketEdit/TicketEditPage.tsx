import React, { useState, useEffect } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import TicketHeader from '../../components/Tickets/TicketHeader';
import TicketForm from '../../components/Tickets/TicketForm';
import RepliesList from '../../components/Replies/RepliesList';
import ReplyForm from '../../components/Replies/ReplyForm';
import { useTickets } from '../../context/TicketsContext';
import { getTicketMetadata } from '../../api/ticketsApi';
import { CreateTicketModel } from '../../api/models/CreateTicketModel';

const TicketEditPage = () => {
    const { id } = useParams();
    const navigate = useNavigate();
    const { fetchTicketById, createTicket, updateTicket } = useTickets();

    const [ticket, setTicket] = useState(
        id
            ? null
            : {
                  title: '',
                  description: '',
                  module: '',
                  urgentLevel: '',
                  type: '',
                  state: '',
                  replies: [],
              }
    );

    const [metadata, setMetadata] = useState({
        urgentLevels: [],
        types: [],
        states: [],
    });

    const [loading, setLoading] = useState(false);
    const [editingReply, setEditingReply] = useState(null);

    useEffect(() => {
        const fetchMetadata = async () => {
            try {
                const data = await getTicketMetadata();
                setMetadata(data);
            } catch (error) {
                console.error('Error fetching metadata:', error);
            }
        };

        fetchMetadata();
    }, []);

    const findId = (title, metadataList) => {
        if (!title) {
            console.warn("Missing title for lookup in metadataList:", metadataList);
            return null;
        }
    
        const item = metadataList.find((m) => m.title.trim().toLowerCase() === title.trim().toLowerCase());
    
        if (!item) {
            console.warn(`No matching item found for title "${title}" in metadataList:`, metadataList);
            return null;
        }
    
        return item.id;
    };

    const prepareCreateTicketModel = (ticket) => {
        const createTicketModel = {
            title: ticket.title,
            module: ticket.module,
            lvl: ticket.lvl,
            type: ticket.type,
            state: ticket.state,
            description: ticket.description,
        };
        return createTicketModel;
    };

    const validateForm = () => {
        const requiredFields = ['title', 'description', 'module', 'lvl', 'type', 'state'];
        for (const field of requiredFields) {
            if (!ticket[field]) {
                alert(`Please fill in the ${field} field.`);
                return false;
            }
        }
        return true;
    };
    

    const handleSave = async () => {
        if (!validateForm()) {
            return; 
        }
    
        try {
            if (ticket.id) {
                await updateTicket(ticket);
            } else {
                const createModel = prepareCreateTicketModel(ticket);
                const createdTicket = await createTicket(createModel);
                setTicket(createdTicket);
            }
            navigate('/tickets');
        } catch (error) {
            console.error('Error saving ticket:', error);
        }
    };

    const handleReplySave = (reply, action) => {
        setTicket((prev) => {
            const updatedReplies =
                action === 'update'
                    ? prev.replies.map((r) => (r.replyId === reply.replyId ? reply : r))
                    : [...prev.replies, reply];
            return { ...prev, replies: updatedReplies };
        });
        setEditingReply(null);
    };

    const handleCancelEdit = () => {
        setEditingReply(null);
    };

    const handleEditReply = (replyId) => {
        const replyToEdit = ticket.replies.find((reply) => reply.replyId === replyId);
        setEditingReply(replyToEdit);
    };

    useEffect(() => {
        if (id) {
            const loadTicket = async () => {
                setLoading(true);
                try {
                    const fetchedTicket = await fetchTicketById(id);
                    setTicket(fetchedTicket);
                } catch (error) {
                    console.error('Error fetching ticket:', error);
                } finally {
                    setLoading(false);
                }
            };

            loadTicket();
        }
    }, [id, fetchTicketById]);

    return (
        <div className="container mt-4">
            <TicketHeader
                ticketNumber={id ? ticket?.number : 'New'}
                ticketTitle={ticket?.title || ''}
                onClose={() => navigate('/tickets')}
                onSave={handleSave}
            />

            {id && (
                <div className="row">
                    <div className="col-12">
                        <ReplyForm
                            ticketId={ticket?.id}
                            reply={editingReply}
                            onSave={handleReplySave}
                            onCancelEdit={handleCancelEdit}
                        />
                    </div>
                </div>
            )}

            <div className="row mt-4">
                <div className="col-md-6">
                    <TicketForm
                        ticket={ticket}
                        metadata={metadata} 
                        onChange={(updatedFields) =>
                            setTicket((prev) => ({ ...prev, ...updatedFields }))
                        }
                    />
                </div>

                <div className="col-md-6">
                    {id && (
                        <RepliesList
                            replies={ticket?.replies || []}
                            onEditReply={handleEditReply}
                        />
                    )}
                </div>
            </div>
        </div>
    );
};

export default TicketEditPage;