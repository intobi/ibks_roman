import React from 'react';

const TextAreaField = ({ label, name, value, onChange }) => (
    <div className="mb-3">
        <label htmlFor={name} className="form-label">{label}</label>
        <textarea
            id={name}
            name={name}
            rows="3"
            className="form-control"
            value={value}
            onChange={onChange}
        />
    </div>
);

export default TextAreaField;