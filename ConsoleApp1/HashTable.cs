namespace aps01;

public class HashTable
{
    private LinkedList<Patient>[] Buckets;
    private int Capacity;

    public HashTable(int capacity = 10)
    {
        Capacity = capacity;
        Buckets = new LinkedList<Patient>[Capacity];

        for (int i = 0; i < capacity; i++)
            Buckets[i] = new LinkedList<Patient>();
    }

    private int Hash(String value) => Math.Abs(value.GetHashCode()) % Capacity;

    public void Insert(Patient patient)
    {
        int index = Hash(patient.Cpf);
        var bucket = Buckets[index];

        if (bucket.Any(p => p.Cpf == patient.Cpf))
            throw new Exception("Patient already registered");

        bucket.AddLast(patient);
    }

    public Patient Search(String value)
    {
        int index = Hash(value);
        return Buckets[index].FirstOrDefault(p => p.Cpf == value);
    }

    public bool Update(Patient patient)
    {
        int index = Hash(patient.Cpf);
        var bucket = Buckets[index];
        var node = bucket.First;
        while (node != null)
        {
            if (node.Value.Cpf == patient.Cpf)
            {
                node.Value = patient;
                return true;
            }
            node = node.Next;
        }
        return false;
    }

    public bool Remove(string value)
    {
        int index = Hash(value);
        var bucket = Buckets[index];
        var node = bucket.First;

        while (node != null)
        {
            if (node.Value.Cpf == value)
            {
                bucket.Remove(node);
                return true;
            }
            node = node.Next;
        }
        return false;
    }
    
}