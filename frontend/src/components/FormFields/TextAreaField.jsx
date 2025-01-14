import React from 'react';
import './TextAreaField.css'; 

const TextAreaField = ({ label, name, value, onChange }) => {
    return (
        <div className="textarea-field-container">
            <label htmlFor={name} className="textarea-field-label">
                {label}
            </label>
            <textarea
                id={name}
                name={name}
                value={value}
                onChange={onChange}
                className="textarea-field-input"
            />
        </div>
    );
};

export default TextAreaField;