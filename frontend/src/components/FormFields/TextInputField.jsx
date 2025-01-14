import React from 'react';
import './TextInputField.css'; 

const TextInputField = ({ label, name, value, onChange }) => {
    return (
        <div className="input-field-container">
            <label htmlFor={name} className="input-field-label">
                {label}
            </label>
            <input
                type="text"
                id={name}
                name={name}
                value={value}
                onChange={onChange}
                className="input-field-input"
            />
        </div>
    );
};

export default TextInputField;