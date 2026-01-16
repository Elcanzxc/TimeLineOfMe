export interface BookRequest {
    title : string;
    description : string;
    author : string;
    publishedDate : string;
}

export const getAllBooks = async () => {
    const response = await fetch("https://localhost:7029/Books");

    return response.json();
};

export const createBook = async (bookrequest: BookRequest) => {
    const response = await fetch("https://localhost:7029/Books", {
        method: "POST",
        headers: {
            "Content-Type": "application/json", // Исправлено
        },
        body: JSON.stringify(bookrequest),
    });

    if (!response.ok) {
        const errorText = await response.text();
        throw new Error(`Ошибка при создании: ${errorText}`);
    }
};

export const updateBook = async (id: string, bookrequest: BookRequest) => {
    const response = await fetch(`https://localhost:7029/Books/${id}`, {
        method: "PUT",
        headers: {
            "Content-Type": "application/json", // Исправлено
        },
        body: JSON.stringify(bookrequest),
    });

    if (!response.ok) {
        const errorText = await response.text();
        throw new Error(`Ошибка при обновлении: ${errorText}`);
    }
};


export const deleteBook = async(id :string)=>{

        await fetch(`https://localhost:7029/Books/${id}`,{
        method:"DELETE"
    });

}