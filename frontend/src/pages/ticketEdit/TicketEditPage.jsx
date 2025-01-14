import React, { useState, useEffect } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import TicketHeader from '../../components/Tickets/TicketHeader';
import TicketForm from '../../components/Tickets/TicketForm';
import RepliesList from '../../components/Replies/RepliesList';
import ReplyForm from '../../components/Replies/ReplyForm';
import { useTickets } from '../../context/TicketsContext';

const TicketEditPage = () => {
    const { id } = useParams();
    const navigate = useNavigate();
    const { fetchTicketById, saveTicket } = useTickets();

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
    const [loading, setLoading] = useState(false);
    const [editingReply, setEditingReply] = useState(null);

    const handleSave = async (formData) => {
        try {
            await saveTicket({ ...formData, id });
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
                onSave={() => handleSave(ticket)}
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
                    <TicketForm ticket={ticket} onSubmit={handleSave} />
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