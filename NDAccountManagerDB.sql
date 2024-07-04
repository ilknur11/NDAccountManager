
-- Create Organizations table
CREATE TABLE Organizations (
    id SERIAL PRIMARY KEY,
    name VARCHAR(100) NOT NULL
);

-- Create Users table
CREATE TABLE Users (
    id SERIAL PRIMARY KEY,
    azure_ad_id VARCHAR(100) NOT NULL UNIQUE,
    name VARCHAR(100) NOT NULL,
    email VARCHAR(100) NOT NULL UNIQUE CHECK (email ~* '^[^@]+@[^@]+\.[^@]+$'),
    organization_id INT,
    FOREIGN KEY (organization_id) REFERENCES Organizations(id)
);

-- Create Categories table
CREATE TABLE Categories (
    id SERIAL PRIMARY KEY,
    name VARCHAR(100) NOT NULL
);

-- Create AccountInfo table
CREATE TABLE AccountInfo (
    id SERIAL PRIMARY KEY,
    user_id INT,
    username VARCHAR(100) NOT NULL,
    password VARCHAR(100) NOT NULL,
    ip_address VARCHAR(100),
    email VARCHAR(100),
    notes TEXT,
    category_id INT,
    is_shared BOOLEAN DEFAULT FALSE,
    shared_with TEXT,
    share_expiry DATE,
    FOREIGN KEY (user_id) REFERENCES Users(id),
    FOREIGN KEY (category_id) REFERENCES Categories(id)
);

-- Create Tags table
CREATE TABLE Tags (
    id SERIAL PRIMARY KEY,
    name VARCHAR(100) NOT NULL
);

-- Create TagAccountInfo join table
CREATE TABLE TagAccountInfo (
    tag_id INT,
    account_info_id INT,
    FOREIGN KEY (tag_id) REFERENCES Tags(id),
    FOREIGN KEY (account_info_id) REFERENCES AccountInfo(id),
    PRIMARY KEY (tag_id, account_info_id)
);


