using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace LIBDG
{
    public class ListOfMembers : ISerializable
    {
        public List<Member> Members { get; set; }

        public ListOfMembers()
        {
            Members = new List<Member>();
        }
         public void RegisterMember(Member newMember)
        {
            bool memberExists = false;

            foreach (Member member in Members)
            {
                if (member.MemberID == newMember.MemberID)
                {
                    memberExists = true;
                    break;
                }
            }

            if (memberExists)
            {
                MessageBox.Show("This student has already existed in library");
            }
            else
            {

                Members.Add(newMember);
                MessageBox.Show("Added this student to library");
            }
        }

        public void RemoveMember(int memberID)
        {
            Member memberToRemove = null;
            foreach (Member member in Members)
            {
                if (member.MemberID == memberID)
                {
                    memberToRemove = member;
                    break;
                }
            }

            if (memberToRemove != null)
            {
                Members.Remove(memberToRemove);
                MessageBox.Show("Removed student from library");
            }

            else
            {
                MessageBox.Show("Cannot find this student in library");
            }
        }

        public void UpdateMemberInfo(Member updatedMember)
        {
            bool memberFound = false;
            foreach (Member member in Members)
            {
                if (member.MemberID == updatedMember.MemberID)
                {
                    member.Name = updatedMember.Name;
                    member.Email = updatedMember.Email;

                    memberFound = true;
                    break;
                }
            }

            if (!memberFound)
            {
                MessageBox.Show("Cannot find this member to update");
            }
        }
        public Member FindMemberByID(int memberID)
        {
            for (int i = 0; i < Members.Count; i++)
            {
                if (Members[i].MemberID == memberID)
                {
                    return Members[i];
                }
            }
            Console.WriteLine("Member not found");
            return null;
        }

        public List<Member> LoadMembersFromJsonAndFind(string filePath, string searchTerm)
        {
            List<Member> foundMembers = new List<Member>();

            if (!File.Exists(filePath))
            {
                MessageBox.Show("File not found.");
                return foundMembers;
            }

            try
            {
                string jsonData = File.ReadAllText(filePath);
                List<Member> loadedMembers = JsonSerializer.Deserialize<List<Member>>(jsonData) ?? new List<Member>();

                foreach (Member member in loadedMembers)
                {
                    if (member.MemberID.ToString().Equals(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                        member.Name.Equals(searchTerm, StringComparison.OrdinalIgnoreCase))
                    {
                        foundMembers.Add(member);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading or parsing file: {ex.Message}");
            }

            return foundMembers;
        }

        public void SerializeData(string filePath)
        {
            try
            {
                string jsonData = JsonSerializer.Serialize(Members);
                File.WriteAllText(filePath, jsonData);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error serializing members data: {ex.Message}");
            }
        }

        public void DeserializeData(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string jsonData = File.ReadAllText(filePath);
                    Members = JsonSerializer.Deserialize<List<Member>>(jsonData) ?? new List<Member>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deserializing members data: {ex.Message}");
            }
        }
    }
}
