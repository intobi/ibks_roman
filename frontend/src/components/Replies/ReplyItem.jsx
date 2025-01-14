import React from 'react';
import './ReplyItem.css';

const ReplyItem = ({ reply, onEdit }) => (
    <div className="reply-item d-flex justify-content-between align-items-center">
        <p>{reply}</p>
        <button className="btn btn-outline-secondary btn-sm" onClick={onEdit}>
            <i className="bi bi-pencil-square"></i>
        </button>
    </div>
);

export default ReplyItem;