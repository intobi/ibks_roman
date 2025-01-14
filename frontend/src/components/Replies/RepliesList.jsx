import React from 'react';
import ReplyItem from './ReplyItem';
import './RepliesList.css';

const RepliesList = ({ replies, onEditReply }) => {
    if (!replies || replies.length === 0) return <p>No replies yet.</p>;

    return (
        <div className="replies-container">
            <div className="replies-header">Replies</div>
            <div className="replies-list">
                {replies.map(({ replyId, reply, replyDate }) => (
                    <ReplyItem
                        key={replyId}
                        replyId={replyId}
                        reply={reply}
                        date={replyDate}
                        onEdit={() => onEditReply(replyId)} 
                    />
                ))}
            </div>
        </div>
    );
};

export default RepliesList;