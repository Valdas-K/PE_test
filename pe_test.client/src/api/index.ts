function getFullUrl(endpoint: string) {
    return `api/${endpoint}`
}
function getHeaders(header = {}) {
    return {
        headers: {
            'X-Requested-With': "XMLHttpRequest",
            ...header,
        },
    }
}

export async function getApi<T>(endpoint: string): Promise<T | undefined> {
    const fullUrl = getFullUrl(endpoint)
    try {
        const result = await fetch(fullUrl, getHeaders())
        return await result.json()
    } catch (e: any) {
        console.error(e.message)
        return
    }
}