
import useSWR from 'swr'
import axios from 'axios'

const fetcher = (url: string) => axios.get(url).then(r => r.data)

export default function Leads() {
  const { data } = useSWR('/api/clients', fetcher)
  return (
    <div>
      <h2>Leads</h2>
      <pre>{JSON.stringify(data || [], null, 2)}</pre>
    </div>
  )
}
