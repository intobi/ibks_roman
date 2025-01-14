import React from 'react';

const ClearButton = ({ onClick }) => {
    return (
        <button
            type="button"
            onClick={onClick}
            style={{
                position: 'absolute',
                top: '8px',
                right: '8px',
                background: 'transparent',
                border: 'none',
                fontSize: '1.2rem',
                cursor: 'pointer',
            }}
            title="Clear text"
        >
            &times;
        </button>
    );
};

export default ClearButton;