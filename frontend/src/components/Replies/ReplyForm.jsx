import React, { useState, useEffect } from 'react';
import { createReply, updateReply } from '../../api/replyApi';
import ClearButton from '../Buttons/ClearButton'; 

const ReplyForm = ({ ticketId, reply, onSave, onCancelEdit  }) => {
    const [text, setText] = useState('');
    const [loading, setLoading] = useState(false);

    useEffect(() => {
        if (reply) {
            setText(reply.reply);
        }
    }, [reply]);

    const handleSubmit = async (e) => {
        e.preventDefault();
        if (!text.trim()) return;

        setLoading(true);
        try {
            let result;
            if (reply) {
                const updatedReply = { ...reply, reply: text };
                result = await updateReply(updatedReply);
                onSave(result, 'update');
            } else {
                const newReply = { ticketId, reply: text };
                result = await createReply(newReply);
                onSave(result, 'create');
            }
            setText('');
        } catch (error) {
            console.error('Error saving reply:', error);
        } finally {
            setLoading(false);
        }
    };

    const handleClear = () => {
        setText('');
        if (reply && onCancelEdit) {
            onCancelEdit(); 
        }
    };

    return (
        <div style={{ position: 'relative', marginBottom: '1rem' }}>
            <form onSubmit={handleSubmit} className="mb-4">
                <textarea
                    className="form-control mb-2"
                    rows="3"
                    placeholder={reply ? 'Update your reply...' : 'Add a new reply...'}
                    value={text}
                    onChange={(e) => setText(e.target.value)}
                    disabled={loading}
                />
                {text && <ClearButton onClick={handleClear} />}
                <button type="submit" className="btn btn-primary" disabled={loading}>
                    {loading ? (reply ? 'Updating...' : 'Adding...') : reply ? 'Update Reply' : 'Add Reply'}
                </button>
            </form>
        </div>
    );
};

export default ReplyForm;