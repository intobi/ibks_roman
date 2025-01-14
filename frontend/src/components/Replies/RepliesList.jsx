import React from 'react';
import ReplyItem from './ReplyItem';

const RepliesList = ({ replies, onEditReply }) => {
    if (!replies || replies.length === 0) return <p>No replies yet.</p>;

    return (
        <div className="mt-4">
            <h4>Replies</h4>
            <div className="list-group">
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